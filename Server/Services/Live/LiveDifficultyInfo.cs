using SunLight.LiveShow.Models;

namespace SunLight.Services.Live;

public class LiveDifficultyInfo
{
    public int LiveDifficultyId { get; set; }
    public int LiveSettingId { get; set; }
    public int Difficulty { get; set; }
    public int StageLevel { get; set; }
    public int AttributeIconId { get; set; }
    public string NotesSettingAsset { get; set; }
    public int AcFlag { get; set; }
    public int SwingFlag { get; set; }
    public int LaneCount { get; set; }
    public IEnumerable<LiveRankInfo> ScoreRank { get; set; }
    public IEnumerable<LiveRankInfo> ComboRank { get; set; }
    public IEnumerable<LiveRankInfo> ClearRank { get; set; }
}