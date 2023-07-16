using SunLight.LiveShow.Models;

namespace SunLight.Dtos.Response.Live;

public class LivePlayResponse
{
    public IEnumerable<LiveRankInfo> RankInfo { get; set; }
    public DateTime EnergyFullTime { get; set; }
    public IEnumerable<LivePlayInfo> LiveList { get; set; }
    public bool AvailableLiveResume { get; set; }
    public bool IsMarathonEvent { get; set; }
    public bool NoSkill { get; set; } // skill issue
    public bool CanActivateEffect { get; set; }
}