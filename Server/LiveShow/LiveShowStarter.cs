using SunLight.LiveShow.Models;
using SunLight.Services.Live;
using SunLight.Services.Unit;

namespace SunLight.LiveShow;

public class LiveShowStarter : ILiveShowStarter
{
    private readonly IUnitDeckService _unitDeckService;
    private readonly ILiveInfoProvider _liveInfoProvider;
    private readonly ILiveNotesService _liveNotesService;

    public LiveShowStarter(IUnitDeckService unitDeckService, ILiveInfoProvider liveInfoProvider,
        ILiveNotesService liveNotesService)
    {
        _unitDeckService = unitDeckService;
        _liveInfoProvider = liveInfoProvider;
        _liveNotesService = liveNotesService;
    }

    public async Task<LiveStartInfo> StartLiveShowAsync(int userId, IEnumerable<int> liveDifficultyIds, int unitDeckId)
    {
        var (liveList, scoreRankInfo) = await GetLiveListForLiveShowAsync(liveDifficultyIds);
        var deck = await _unitDeckService.GetUserDeckForLiveShowAsync(userId, unitDeckId);

        var liveListWithDeck = liveList.Select(liveInfo => new LivePlayInfo
        {
            LiveInfo = liveInfo,
            DeckInfo = deck
        });

        var result = new LiveStartInfo
        {
            LiveList = liveListWithDeck,
            RankInfo = scoreRankInfo
        };

        return result;
    }

    private async Task<(IEnumerable<LiveInfo> liveList, IEnumerable<LiveRankInfo> scoreRankInfo)>
        GetLiveListForLiveShowAsync(IEnumerable<int> liveDifficultyIds)
    {
        var liveList = new List<LiveInfo>();
        var scorePointsTotal = 0;

        foreach (var liveDifficultyId in liveDifficultyIds)
        {
            var liveDifficultyInfo = await _liveInfoProvider.GetLiveDifficultyInfoAsync(liveDifficultyId);
            var notesList = await _liveNotesService.GetLiveNotesAsync(liveDifficultyInfo.NotesSettingAsset);

            var liveInfo = new LiveInfo
            {
                LiveDifficultyId = liveDifficultyId,
                AcFlag = liveDifficultyInfo.AcFlag,
                SwingFlag = liveDifficultyInfo.SwingFlag,
                IsRandom = false, // TODO
                NotesList = notesList
            };

            liveList.Add(liveInfo);
            scorePointsTotal += liveDifficultyInfo.ScoreRank.First(s => s.Rank == 1).RankMin;
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
            new() { Rank = 5, RankMin = 0, RankMax = cRank - 1 }, // D
            new() { Rank = 4, RankMin = cRank, RankMax = bRank - 1 }, // C
            new() { Rank = 3, RankMin = bRank, RankMax = aRank - 1 }, // B
            new() { Rank = 2, RankMin = aRank, RankMax = totalScore - 1 }, // A
            new() { Rank = 1, RankMin = totalScore, RankMax = 0 }, // S
        };
    }
}