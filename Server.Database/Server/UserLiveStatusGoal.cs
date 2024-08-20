using Microsoft.EntityFrameworkCore;

namespace Server.Database.Server;

[PrimaryKey(nameof(UserLiveStatusGoalId))]
public class UserLiveStatusGoal
{
    public int UserLiveStatusGoalId { get; set; }
    public int UserLiveStatusId { get; set; }
    public int LiveGoalRewardId { get; set; }
    
    public virtual UserLiveStatus UserLiveStatus { get; set; }
}
