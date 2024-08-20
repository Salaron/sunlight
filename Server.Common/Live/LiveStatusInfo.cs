using Server.Database.Enums;

namespace Server.Common.Live;

public record LiveStatusInfo
{
    public int UserId { get; init; }
    public LiveStatus Status { get; init; }
    public int LiveDifficultyId { get; init; }
    public int HiScore { get; init; }
    public int HiComboCount { get; init; }
    public int ClearCnt { get; init; }
    public List<int> AchievedGoalIdList { get; init; }
}