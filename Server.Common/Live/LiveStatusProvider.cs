using Microsoft.EntityFrameworkCore;
using Server.Database.Game;
using Server.Database.Server;

namespace Server.Common.Live;

internal class LiveStatusProvider(LiveContext liveContext, ServerContext serverContext) : ILiveStatusProvider
{
    public async Task<IEnumerable<LiveStatusInfo>> GetNormalLiveStatusAsync(int userId)
    {
        var normalLives = await liveContext.NormalLiveM.Select(live => live.LiveDifficultyId).ToListAsync();

        var userLiveStatus = await serverContext.UserLiveStatus
            .Where(live => live.UserId == userId && normalLives.Contains(live.LiveDifficultyId))
            .Include(live => live.AchievedGoalIdList)
            .ToListAsync();

        return userLiveStatus.Select(ConvertToLiveStatusInfo);
    }
    
    public async Task<IEnumerable<LiveStatusInfo>> GetSpecialLiveStatusAsync(int userId)
    {
        var specialLives = await liveContext.SpecialLiveM.Select(live => live.LiveDifficultyId).ToListAsync();

        var userLiveStatus = await serverContext.UserLiveStatus
            .Where(live => live.UserId == userId && specialLives.Contains(live.LiveDifficultyId))
            .Include(live => live.AchievedGoalIdList)
            .ToListAsync();

        return userLiveStatus.Select(ConvertToLiveStatusInfo);
    }

    private LiveStatusInfo ConvertToLiveStatusInfo(UserLiveStatus userLiveStatus)
    {
        return new LiveStatusInfo
        {
            UserId = userLiveStatus.UserId,
            Status = userLiveStatus.Status,
            LiveDifficultyId = userLiveStatus.LiveDifficultyId,
            HiScore = userLiveStatus.HiScore,
            HiComboCount = userLiveStatus.HiComboCount,
            ClearCnt = userLiveStatus.ClearCnt,
            AchievedGoalIdList = userLiveStatus.AchievedGoalIdList.Select(goal => goal.UserLiveStatusGoalId).ToList(),
        };
    }
}