using SunLight.Modules.Live.LiveShow.Models;

namespace SunLight.Modules.Live.LiveShow;

public class LiveStartInfo
{
    public IEnumerable<LiveRankInfo> RankInfo { get; set; }
    public IEnumerable<LivePlayInfo> LiveList { get; set; }
}