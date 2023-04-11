using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Live;

[PrimaryKey(nameof(LiveSettingId))]
public class LiveSettingM
{
    public int LiveSettingId { get; set; }
    public int LiveTrackId { get; set; }
    public int Difficulty { get; set; }
    public int StageLevel { get; set; }
    public int AttributeIconId { get; set; }
    public string LiveIconAsset { get; set; }
    public string LiveIconAssetEn { get; set; }
    public int? AssetMovieId { get; set; }
    public int AssetBackgroundId { get; set; }
    public string NotesSettingAsset { get; set; }
    public string NotesSettingAssetEn { get; set; }
    public int CRankScore { get; set; }
    public int BRankScore { get; set; }
    public int ARankScore { get; set; }
    public int SRankScore { get; set; }
    public int CRankCombo { get; set; }
    public int BRankCombo { get; set; }
    public int ARankCombo { get; set; }
    public int SRankCombo { get; set; }
    public int AcFlag { get; set; }
    public int SwingFlag { get; set; }
    public int LaneCount { get; set; }
}
