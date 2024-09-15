using Server.Database.Enums;

namespace Server.Common.Items;

public record GameItem(AddType AddType, int Amount, int? ItemId = null, int? UnitId = null) : IItem;