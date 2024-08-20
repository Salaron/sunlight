using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public class LiveItem(int liveDifficultyId) : IItem
{
    public AddType AddType => AddType.Live;
    public int LiveDifficultyId => liveDifficultyId;
}

internal class LiveHandler(ServerContext serverContext) : AddTypeHandler<LiveItem, EmptyObject>
{
    public override AddType AddType => AddType.Live;

    public override async Task<EmptyObject> AddAsync(int userId, LiveItem item)
    {
        var liveStatus = serverContext.UserLiveStatus.SingleOrDefault(u => u.UserId == userId && u.LiveDifficultyId == item.LiveDifficultyId);
        if (liveStatus != null)
            return new EmptyObject();
        
        liveStatus = new UserLiveStatus
        {
            UserId = userId,
            LiveDifficultyId = item.LiveDifficultyId,
            Status = LiveStatus.New,
        };

        serverContext.UserLiveStatus.Add(liveStatus);
        await serverContext.SaveChangesAsync();
        
        return new EmptyObject();
    }

    public override Task<EmptyObject> SubtractAsync(int userId, LiveItem item)
    {
       throw new NotImplementedException();
    }
}