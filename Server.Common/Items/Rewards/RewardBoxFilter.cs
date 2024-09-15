namespace Server.Common.Items;

public record RewardBoxFilter(
    RewardBoxOrder Order,
    RewardBoxCategory Category,
    List<int> Filters,
    int Limit,
    int Offset = 0);