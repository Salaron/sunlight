using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Server.Common.Json;
using Server.Database.Game;

namespace Server.Common.Live;

internal class LiveInfoProvider(LiveContext liveContext, LiveNotesContext liveNotesContext) : ILiveInfoProvider
{
    public async Task<LiveDifficulty> GetLiveDifficultyAsync(int liveDifficultyId)
    {
        // normal + special lives
        var liveInfoQuery = liveContext.LiveSettingM
            .Join(
                liveContext.SpecialLiveM
                    .Select(specialLive => new
                    {
                        specialLive.LiveSettingId,
                        specialLive.LiveDifficultyId,
                        specialLive.CapitalType,
                        specialLive.CapitalValue,
                        specialLive.CRankComplete,
                        specialLive.BRankComplete,
                        specialLive.ARankComplete,
                        specialLive.SRankComplete
                    })
                    .Concat(
                        liveContext.NormalLiveM
                            .Select(normalLive => new
                            {
                                normalLive.LiveSettingId,
                                normalLive.LiveDifficultyId,
                                normalLive.CapitalType,
                                normalLive.CapitalValue,
                                normalLive.CRankComplete,
                                normalLive.BRankComplete,
                                normalLive.ARankComplete,
                                normalLive.SRankComplete
                            })
                    ),
                setting => setting.LiveSettingId,
                difficulty => difficulty.LiveSettingId,
                (setting, difficulty) => new { setting, difficulty }
            )
            .Where(joined => joined.difficulty.LiveDifficultyId == liveDifficultyId)
            .Select(joined => new LiveDifficulty
            {
                LiveDifficultyId = joined.difficulty.LiveDifficultyId,
                LiveSettingId = joined.setting.LiveSettingId,
                Difficulty = joined.setting.Difficulty,
                StageLevel = joined.setting.StageLevel,
                AttributeIconId = joined.setting.AttributeIconId,
                NotesSettingAsset = joined.setting.NotesSettingAsset,
                AcFlag = joined.setting.AcFlag,
                SwingFlag = joined.setting.SwingFlag,
                LaneCount = joined.setting.LaneCount,
                ScoreRank = GetRankInfo(joined.setting.CRankScore, joined.setting.BRankScore, joined.setting.ARankScore,
                    joined.setting.SRankScore),
                ComboRank = GetRankInfo(joined.setting.CRankCombo, joined.setting.BRankCombo, joined.setting.ARankCombo,
                    joined.setting.SRankCombo),
                ClearRank = GetRankInfo(joined.difficulty.CRankComplete, joined.difficulty.BRankComplete,
                    joined.difficulty.ARankComplete, joined.difficulty.SRankComplete)
            });

        var liveInfo = await liveInfoQuery.FirstOrDefaultAsync();
        if (liveInfo != null)
            return liveInfo;

        // festival
        // token
        // more?
        throw new NotImplementedException();
    }
    
    public async Task<IReadOnlyList<LiveShowNote>> GetLiveNotesAsync(string notesSettingAsset, NoteMods mods)
    {
        var notes = await liveNotesContext.LiveNotes.FirstOrDefaultAsync(note => note.NotesSettingAsset == notesSettingAsset);
        if (notes == null)
            throw new Exception(); // TODO
        
        var liveNotes = JsonSerializer.Deserialize<List<LiveShowNote>>(notes.Json, JsonSerializerDefaultOptions.GetOptions());
        return liveNotes;
    }

    private static IEnumerable<LiveRankInfo> GetRankInfo(int cRank, int bRank, int aRank, int sRank)
    {
        return new List<LiveRankInfo>
        {
            new() { Rank = LiveRank.RankD, RankMin = 0, RankMax = cRank - 1 },
            new() { Rank = LiveRank.RankC, RankMin = cRank, RankMax = bRank - 1 },
            new() { Rank = LiveRank.RankB, RankMin = bRank, RankMax = aRank - 1 },
            new() { Rank = LiveRank.RankA, RankMin = aRank, RankMax = sRank - 1 },
            new() { Rank = LiveRank.RankS, RankMin = sRank, RankMax = 0 },
        };
    }
}