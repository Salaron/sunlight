using Server.Database.Enums;

namespace Server.Common.Items;

public record RewardItem(int IncentiveId, AddType AddType, int Amount, int? ItemId = null, int? UnitId = null)
    : GameItem(AddType, Amount, ItemId, UnitId)
{
    public bool RewardBoxFlag => false;
}