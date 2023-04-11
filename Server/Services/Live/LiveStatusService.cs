using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game;
using SunLight.Database.Server;

namespace SunLight.Services.Live;

internal class LiveStatusService : ILiveStatusService
{
    private readonly LiveDbContext _liveDbContext;
    private readonly ServerDbContext _serverDbContext;

    public LiveStatusService(LiveDbContext liveDbContext, ServerDbContext serverDbContext)
    {
        _liveDbContext = liveDbContext;
        _serverDbContext = serverDbContext;
    }

    public async Task<IEnumerable<LiveStatus>> GetNormalLiveStatusAsync(int userId)
    {
        var normalLives = await _liveDbContext.NormalLiveM.Select(live => live.LiveDifficultyId).ToListAsync();

        var userLiveStatus = await _serverDbContext.LiveStatus.Where(live => live.UserId == userId && normalLives.Contains(live.LiveDifficultyId)).ToListAsync();
        var playedLives = userLiveStatus.Select(live => live.LiveDifficultyId);

        var result = new List<LiveStatus>();
        result.AddRange(userLiveStatus);
        result.AddRange(normalLives.Where(live => !playedLives.Contains(live)).Select(l => new LiveStatus
        {
            Status = 1,
            LiveDifficultyId = l,
            HiScore = 0,
            HiComboCount = 0,
            ClearCnt = 0,
        }));

        return result;
    }

    public async Task<IEnumerable<LiveStatus>> GetSpecialLiveStatusAsync(int userId)
    {
        var specialLives = await _liveDbContext.SpecialLiveM.Select(live => live.LiveDifficultyId).ToListAsync();

        var userLiveStatus = await _serverDbContext.LiveStatus.Where(live => live.UserId == userId && specialLives.Contains(live.LiveDifficultyId)).ToListAsync();
        var playedLives = userLiveStatus.Select(live => live.LiveDifficultyId);

        var result = new List<LiveStatus>();
        result.AddRange(userLiveStatus);
        result.AddRange(specialLives.Where(live => !playedLives.Contains(live)).Select(l => new LiveStatus
        {
            Status = 1,
            LiveDifficultyId = l,
            HiScore = 0,
            HiComboCount = 0,
            ClearCnt = 0,
        }));

        return result;
    }
}