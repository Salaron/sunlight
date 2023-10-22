using SunLight.Services.Live;

namespace SunLight.Modules.Live.LiveShow.Models;

public class LiveRankInfo
{
    public LiveRank Rank { get; set; }
    public int RankMin { get; set; }
    public int RankMax { get; set; }
}