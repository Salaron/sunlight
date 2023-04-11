using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

[PrimaryKey(nameof(LiveStatusGoalId))]
public class LiveStatusGoal
{
    public int LiveStatusGoalId { get; set; }
    public int LiveStatusId { get; set; }
    public int LiveGoalRewardId { get; set; }
    
    public virtual LiveStatus LiveStatus { get; set; }
}
