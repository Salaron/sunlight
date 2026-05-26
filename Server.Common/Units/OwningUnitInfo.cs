namespace Server.Common.Units;

public record OwningUnitInfo : UnitInfo
{
    public int UnitOwningUserId { get; init; }
    public DateTime InsertDate { get; init; }
}