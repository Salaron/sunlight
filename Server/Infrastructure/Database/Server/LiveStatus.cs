using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Server;

[PrimaryKey(nameof(LiveStatusId))]
public class LiveStatus
{
    public int LiveStatusId { get; set; }
    public int UserId { get; set; }
    public int Status { get; set; }
    public int LiveDifficultyId { get; set; }
    public int HiScore { get; set; }
    public int HiComboCount { get; set; }
    public int ClearCnt { get; set; }

    public virtual User User { get; set; }
    public virtual List<LiveStatusGoal> AchievedGoalIdList { get; set; }
}