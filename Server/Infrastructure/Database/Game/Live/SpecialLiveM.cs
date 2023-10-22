using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Game.Live;

[PrimaryKey(nameof(LiveDifficultyId))]
public class SpecialLiveM
{
    public int LiveDifficultyId { get; set; }
    public int LiveSettingId { get; set; }
    public int CapitalType { get; set; }
    public int CapitalValue { get; set; }
    public int CRankComplete { get; set; }
    public int BRankComplete { get; set; }
    public int ARankComplete { get; set; }
    public int SRankComplete { get; set; }
    public int ExcludeClearCountFlag { get; set; }
    public int ExcludeEffortPointFlag { get; set; }
    public int ExcludeLiveBonusFlag { get; set; }
    
    public virtual LiveSettingM LiveSetting { get; set; }
}
