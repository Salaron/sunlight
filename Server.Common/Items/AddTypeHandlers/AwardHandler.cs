using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public record AwardItem(int AwardId) : IItem
{
    public AddType AddType => AddType.Award;
}

internal class AwardHandler(ServerContext serverContext) : AddTypeHandler<AwardItem, EmptyObject>
{
    public override AddType AddType => AddType.Award;

    public override async Task<EmptyObject> AddAsync(int userId, AwardItem item)
    {
        var awardUnlock = serverContext.UserItemUnlock.SingleOrDefault(u => u.AddType == AddType.Award && u.ItemId == item.AwardId);
        if (awardUnlock != null)
            return new EmptyObject();
        
        awardUnlock = new UserItemUnlock
        {
            UserId = userId,
            AddType = AddType.Award,
            ItemId = item.AwardId,
        };

        serverContext.UserItemUnlock.Add(awardUnlock);
        await serverContext.SaveChangesAsync();
        
        return new EmptyObject();
    }

    public override async Task<EmptyObject> SubtractAsync(int userId, AwardItem item)
    {
        var awardUnlock = await serverContext.UserItemUnlock.SingleOrDefaultAsync(u => u.AddType == AddType.Award && u.ItemId == item.AwardId);
        if (awardUnlock == null)
            return new EmptyObject();
        
        serverContext.UserItemUnlock.Remove(awardUnlock);
        await serverContext.SaveChangesAsync();

        return new EmptyObject();
    }
}