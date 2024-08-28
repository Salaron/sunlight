using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public record ExchangePointItem(int Rarity, int Amount) : IItem
{
    public AddType AddType => AddType.ExchangePoint;
}

public record ExchangeItemOwning(int Rarity, int Amount);

internal class ExchangePointHandler(ServerContext serverContext) : AddTypeHandler<ExchangePointItem, ExchangeItemOwning>
{
    public override AddType AddType => AddType.ExchangePoint;

    public override Task<ExchangeItemOwning> AddAsync(int userId, ExchangePointItem item)
    {
        if (item.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    public override Task<ExchangeItemOwning> SubtractAsync(int userId, ExchangePointItem item)
    {
        if (item.Amount > 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    private async Task<ExchangeItemOwning> ModifyAsync(int userId, ExchangePointItem item)
    {
        var owningItem = await serverContext.UserItems.FirstOrDefaultAsync(i =>
            i.UserId == userId && i.ItemType == (int)item.AddType && i.ItemId == item.Rarity);

        if (owningItem == null)
            owningItem = new UserItems
            {
                UserId = userId,
                ItemType = (int)item.AddType,
                ItemId = item.Rarity,
                Amount = item.Amount
            };
        else
            owningItem.Amount += item.Amount;

        serverContext.Update(owningItem);

        return new ExchangeItemOwning(owningItem.ItemId, owningItem.Amount);
    }
}