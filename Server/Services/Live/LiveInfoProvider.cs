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
        // normal + special lives
        var liveInfoQuery = from setting in _liveDbContext.LiveSettingM
            join difficulty in (
                    from specialLive in _liveDbContext.SpecialLiveM
                    select new
                    {
                        specialLive.LiveSettingId,
                        specialLive.LiveDifficultyId,
                        specialLive.CapitalType,
                        specialLive.CapitalValue,
                        specialLive.CRankComplete,
                        specialLive.BRankComplete,
                        specialLive.ARankComplete,
                        specialLive.SRankComplete
                    }
                ).Concat(
                    from normalLive in _liveDbContext.NormalLiveM
                    select new
                    {
                        normalLive.LiveSettingId,
                        normalLive.LiveDifficultyId,
                        normalLive.CapitalType,
                        normalLive.CapitalValue,
                        normalLive.CRankComplete,
                        normalLive.BRankComplete,
                        normalLive.ARankComplete,
                        normalLive.SRankComplete
                    }
                )
                on setting.LiveSettingId equals difficulty.LiveSettingId
            where difficulty.LiveDifficultyId == liveDifficultyId
            select new LiveDifficultyInfo
            {
                LiveDifficultyId = difficulty.LiveDifficultyId,
                LiveSettingId = setting.LiveSettingId,
                Difficulty = setting.Difficulty,
                StageLevel = setting.StageLevel,
                AttributeIconId = setting.AttributeIconId,
                NotesSettingAsset = setting.NotesSettingAsset,
                AcFlag = setting.AcFlag,
                SwingFlag = setting.SwingFlag,
                LaneCount = setting.LaneCount,
                ScoreRank = ConstructRankInfo(setting.CRankScore, setting.BRankScore, setting.ARankScore,
                    setting.SRankScore),
                ComboRank = ConstructRankInfo(setting.CRankCombo, setting.BRankCombo, setting.ARankCombo,
                    setting.SRankCombo),
                ClearRank = ConstructRankInfo(difficulty.CRankComplete, difficulty.BRankComplete,
                    difficulty.ARankComplete, difficulty.SRankComplete)
            };

        var liveInfo = await liveInfoQuery.FirstOrDefaultAsync();
        if (liveInfo != null)
            return liveInfo;

        // festival
        // token
        // more?
        throw new NotImplementedException();
    }

    private static IEnumerable<LiveRankInfo> ConstructRankInfo(int cRank, int bRank, int aRank, int sRank)
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