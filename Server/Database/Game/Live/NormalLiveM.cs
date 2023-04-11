using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Live;

[PrimaryKey(nameof(LiveDifficultyId))]
public class NormalLiveM
{
    public int LiveDifficultyId { get; set; }
    public int LiveSettingId { get; set; }
    public int CapitalType { get; set; }
    public int CapitalValue { get; set; }
    public int DefaultUnlockedFlag { get; set; }
    public int CRankComplete { get; set; }
    public int BRankComplete { get; set; }
    public int ARankComplete { get; set; }
    public int SRankComplete { get; set; }

    public virtual LiveSettingM LiveSetting { get; set; }
}
