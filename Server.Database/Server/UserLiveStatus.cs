using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;

namespace Server.Database.Server;

[PrimaryKey(nameof(UserLiveStatusId))]
public class UserLiveStatus
{
    public int UserLiveStatusId { get; set; }
    public int UserId { get; set; }
    public LiveStatus Status { get; set; }
    public int LiveDifficultyId { get; set; }
    public int HiScore { get; set; }
    public int HiComboCount { get; set; }
    public int ClearCnt { get; set; }

    public virtual User User { get; set; }
    public virtual List<UserLiveStatusGoal> AchievedGoalIdList { get; set; }
}