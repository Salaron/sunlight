using SunLight.LiveShow.Models;

namespace SunLight.LiveShow;

public class LiveStartInfo
{
    public IEnumerable<LiveRankInfo> RankInfo { get; set; }
    public IEnumerable<LivePlayInfo> LiveList { get; set; }
}