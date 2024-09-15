using Server.Common.Units;

namespace Server.Common.Live;

internal class LiveShowStarter(
    IUnitDeckService unitDeckService,
    ILiveInfoProvider liveInfoProvider) : ILiveShowStarter
{
    public async Task<LiveStartInfo> StartLiveShowAsync(int userId, IEnumerable<int> liveDifficultyIds, int unitDeckId)
    {
        var (liveList, scoreRankInfo) = await GetLiveShowListAsync(liveDifficultyIds);
        var deck = await unitDeckService.GetDeckForLiveShowAsync(userId, unitDeckId);

        var liveListWithDeck = liveList.Select(liveInfo => new LiveInfoWithDeck
        {
            LiveInfo = liveInfo,
            DeckInfo = deck
        });

        var result = new LiveStartInfo
        {
            LiveList = liveListWithDeck,
            ScoreRank = scoreRankInfo
        };

        return result;
    }

    private async Task<(IEnumerable<LiveShow> liveList, IEnumerable<LiveRankInfo> scoreRankInfo)>
        GetLiveShowListAsync(IEnumerable<int> liveDifficultyIds)
    {
        var liveList = new List<LiveShow>();
        var scorePointsTotal = 0;

        foreach (var liveDifficultyId in liveDifficultyIds)
        {
            var liveDifficultyInfo = await liveInfoProvider.GetLiveDifficultyAsync(liveDifficultyId);
            var notesList = await liveInfoProvider.GetLiveNotesAsync(liveDifficultyInfo.NotesSettingAsset, NoteMods.None);

            var liveInfo = new LiveShow
            {
                LiveDifficultyId = liveDifficultyId,
                AcFlag = liveDifficultyInfo.AcFlag,
                SwingFlag = liveDifficultyInfo.SwingFlag,
                IsRandom = false, // TODO
                NotesList = notesList
            };

            liveList.Add(liveInfo);
            scorePointsTotal += liveDifficultyInfo.ScoreRank.First(s => s.Rank == LiveRank.RankS).RankMin;
        }

        var scoreRankInfo = CalculateScoreRankInfo(scorePointsTotal);
        return (liveList, scoreRankInfo);
    }

    private IEnumerable<LiveRankInfo> CalculateScoreRankInfo(int totalScore)
    {
        var cRank = (int)Math.Ceiling(totalScore * 0.4);
        var bRank = (int)Math.Ceiling(totalScore * 0.6);
        var aRank = (int)Math.Ceiling(totalScore * 0.8);
        return new List<LiveRankInfo>
        {
            new() { Rank = LiveRank.RankD, RankMin = 0, RankMax = cRank - 1 },
            new() { Rank = LiveRank.RankC, RankMin = cRank, RankMax = bRank - 1 },
            new() { Rank = LiveRank.RankB, RankMin = bRank, RankMax = aRank - 1 },
            new() { Rank = LiveRank.RankA, RankMin = aRank, RankMax = totalScore - 1 },
            new() { Rank = LiveRank.RankS, RankMin = totalScore, RankMax = 0 },
        };
    }
}