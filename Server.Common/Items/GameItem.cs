using Server.Database.Enums;

namespace Server.Common.Items;

public class GameItem(AddType addType, int amount, int? itemId = null, int? unitId = null) : IItem
{
    public AddType AddType { get; set; } = addType;
    public int Amount { get; set; } = amount;
    public int? ItemId { get; set; } = itemId;
    public int? UnitId { get; set; } = unitId;
}
