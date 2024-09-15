using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Server.Common.Unit;
using Server.Database.Enums;
using Server.Database.Game;
using Server.Database.Server;

namespace Server.Common.Items;

internal class RewardBox(
    ServerContext serverContext,
    ItemManager itemManager,
    IUnitService unitService,
    UnitContext unitContext) : IRewardBox
{
    public async Task<IReadOnlyList<RewardBoxItem>> GetAsync(int userId, RewardBoxFilter filter)
    {
        var addType = Array.Empty<AddType>();
        var itemIds = new List<int>();

        switch (filter.Category)
        {
            case RewardBoxCategory.Unit:
                addType = [AddType.Unit];
                var rarity = filter.Filters[0];
                var attribute = filter.Filters[1];
                var isNotInAlbum = filter.Filters[2] == 1;

                if (filter.Filters.Any(f => f != 0))
                {
                    var query = unitContext.UnitM.AsQueryable();
                    if (rarity != 0)
                        query = query.Where(unit => unit.Rarity == rarity);

                    if (attribute != 0)
                        query = query.Where(unit => unit.AttributeId == attribute);

                    if (isNotInAlbum)
                    {
                        var unitAlbum = await unitService.GetAlbumAsync(userId);
                        var unitAlbumIds = unitAlbum.Select(unit => unit.UnitId);
                        query = query.Where(unit => !unitAlbumIds.Contains(unit.UnitId));
                    }

                    itemIds = query.Select(unit => unit.UnitId).ToList();
                }

                break;
            case RewardBoxCategory.Item:
                if (filter.Filters.First() == 0)
                    addType = Enum.GetValues<AddType>().Except([AddType.Unit]).ToArray();
                else
                    addType = filter.Filters.Select(type => (AddType)type).ToArray();
                break;
        }

        var rewardsQuery = serverContext.RewardBoxItems
            .Where(NotClaimedAndNotExpired())
            .Where(item => item.UserId == userId);

        if (addType.Length != 0)
            rewardsQuery = rewardsQuery.Where(item => addType.Contains(item.AddType));

        if (itemIds.Any())
            rewardsQuery = rewardsQuery.Where(item => item.ItemId.HasValue)
                .Where(item => itemIds.Contains(item.ItemId!.Value));

        var orderedRewards = rewardsQuery.OrderBy(item => item.InsertDate,
            filter.Order.HasFlag(RewardBoxOrder.Ascending) ? OrderType.Ascending : OrderType.Descending);

        if (filter.Order.HasFlag(RewardBoxOrder.ExpireFirst))
            orderedRewards = orderedRewards.ThenByDescending(item => item.ExpireDate);

        var result = orderedRewards.Skip(filter.Offset).Take(filter.Limit);
        return await result.ToListAsync();
    }

    public Task<int> GetTotalAsync(int userId) => serverContext.RewardBoxItems
        .Where(NotClaimedAndNotExpired())
        .CountAsync(item => item.UserId == userId);

    public async Task AddAsync(int userId, GameItem item, string message, DateTime? expireDate, bool autoOpen)
    {
        var rewardBoxItem = new RewardBoxItem
        {
            UserId = userId,
            AddType = item.AddType,
            ItemId = item.ItemId,
            Amount = item.Amount,
            Message = message,
            ExpireDate = expireDate
        };
        await serverContext.RewardBoxItems.AddAsync(rewardBoxItem);

        if (autoOpen)
        {
            await serverContext.SaveChangesAsync(); // todo
            await OpenAsync(userId, rewardBoxItem.Id);
        }
    }

    public async Task<RewardItem> OpenAsync(int userId, int rewardBoxItemId)
    {
        var rewardBoxItem = serverContext.RewardBoxItems
            .Where(NotClaimedAndNotExpired())
            .SingleOrDefault(item => item.UserId == userId && item.Id == rewardBoxItemId);
        if (rewardBoxItem is null)
            throw new ItemNotFoundException();

        rewardBoxItem.OpenDate = DateTime.UtcNow;
        serverContext.RewardBoxItems.Update(rewardBoxItem);

        var gameItem = new GameItem(rewardBoxItem.AddType, rewardBoxItem.Amount, rewardBoxItem.ItemId);
        await itemManager.AddAsync(userId, Item.FromGameItem(gameItem));

        return new RewardItem(rewardBoxItemId, rewardBoxItem.AddType, rewardBoxItem.Amount, rewardBoxItem.ItemId);
    }

    private static Expression<Func<RewardBoxItem, bool>> NotClaimedAndNotExpired() => item =>
        item.OpenDate == null && (item.ExpireDate == null || item.ExpireDate < DateTime.UtcNow);
}