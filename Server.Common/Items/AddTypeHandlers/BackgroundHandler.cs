using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public record BackgroundItem(int BackgroundId) : IItem
{
    public AddType AddType => AddType.Background;
}

internal class BackgroundHandler(ServerContext serverContext) : AddTypeHandler<BackgroundItem, EmptyObject>
{
    public override AddType AddType => AddType.Background;

    public override async Task<EmptyObject> AddAsync(int userId, BackgroundItem item)
    {
        var backgroundUnlock = serverContext.UserItemUnlock.SingleOrDefault(u => u.AddType == AddType.Background && u.ItemId == item.BackgroundId);
        if (backgroundUnlock != null)
            return new EmptyObject();

        backgroundUnlock = new UserItemUnlock
        {
            UserId = userId,
            AddType = AddType.Background,
            ItemId = item.BackgroundId,
        };

        serverContext.UserItemUnlock.Add(backgroundUnlock);
        await serverContext.SaveChangesAsync();
        
        return new EmptyObject();
    }

    public override async Task<EmptyObject> SubtractAsync(int userId, BackgroundItem item)
    {
        var backgroundUnlock = await serverContext.UserItemUnlock.SingleOrDefaultAsync(u => u.AddType == AddType.Background && u.ItemId == item.BackgroundId);
        if (backgroundUnlock == null)
            return new EmptyObject();
        
        serverContext.UserItemUnlock.Remove(backgroundUnlock);
        await serverContext.SaveChangesAsync();

        return new EmptyObject();
    }
}