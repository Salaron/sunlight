using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public record UnlockedItem(AddType AddType, int ItemId, DateTime UnlockDate);

internal class UnlockedItemsProvider(ServerContext serverContext) : IUnlockedItemsProvider
{
    public async Task<bool> IsItemUnlockedAsync(int userId, AddType addType, int itemId)
    {
        var itemUnlock = await serverContext.UserItemUnlock.SingleOrDefaultAsync(i =>
            i.UserId == userId && i.AddType == addType && i.ItemId == itemId);
        var isUnlocked = itemUnlock is not null;

        return isUnlocked;
    }

    public async Task<IReadOnlyList<UnlockedItem>> GetUnlockedAsync(int userId, AddType addType)
    {
        var items = await serverContext.UserItemUnlock
            .Where(i => i.UserId == userId && i.AddType == addType)
            .Select(i => new UnlockedItem(i.AddType, i.ItemId, i.InsertDate))
            .ToListAsync();

        return items;
    }
}