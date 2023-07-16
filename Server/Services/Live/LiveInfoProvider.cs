using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game;
using SunLight.LiveShow.Models;

namespace SunLight.Services.Live;

public class LiveInfoProvider : ILiveInfoProvider
{
    private readonly LiveDbContext _liveDbContext;

    public LiveInfoProvider(LiveDbContext liveDbContext)
    {
        _liveDbContext = liveDbContext;
    }

    public async Task<LiveDifficultyInfo> GetLiveDifficultyInfoAsync(int liveDifficultyId)
    {
        // normal, special
        var result = await _liveDbContext.NormalLiveM.Include(l => l.LiveSetting)
            .FirstOrDefaultAsync(live => live.LiveDifficultyId == liveDifficultyId);

        if (result != null)
        {
            return new LiveDifficultyInfo
            {
                LiveDifficultyId = result.LiveDifficultyId,
                LiveSettingId = result.LiveSettingId,
                Difficulty = result.LiveSetting.Difficulty,
                StageLevel = result.LiveSetting.StageLevel,
                AttributeIconId = result.LiveSetting.AttributeIconId,
                NotesSettingAsset = result.LiveSetting.NotesSettingAsset,
                AcFlag = result.LiveSetting.AcFlag,
                SwingFlag = result.LiveSetting.SwingFlag,
                LaneCount = result.LiveSetting.LaneCount,
                ScoreRank = ConstructRankInfo(result.LiveSetting.CRankScore, result.LiveSetting.BRankScore, 
                    result.LiveSetting.ARankScore, result.LiveSetting.SRankScore),
                ComboRank = ConstructRankInfo(result.LiveSetting.CRankCombo, result.LiveSetting.BRankCombo, 
                    result.LiveSetting.ARankCombo, result.LiveSetting.SRankCombo),
                ClearRank = ConstructRankInfo(result.CRankComplete, result.BRankComplete, 
                    result.ARankComplete, result.SRankComplete),
            };
        }

        throw new NotImplementedException();

        // festival

        // token

        // more?
    }

    private IEnumerable<LiveRankInfo> ConstructRankInfo(int cRank, int bRank, int aRank, int sRank)
    {
        return new List<LiveRankInfo>
        {
            new() { Rank = 5, RankMin = 0, RankMax = cRank - 1 }, // D
            new() { Rank = 4, RankMin = cRank, RankMax = bRank - 1 }, // C
            new() { Rank = 3, RankMin = bRank, RankMax = aRank - 1 }, // B
            new() { Rank = 2, RankMin = aRank, RankMax = sRank - 1 }, // A
            new() { Rank = 1, RankMin = sRank, RankMax = 0 }, // S
        };
    }
}