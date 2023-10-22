using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Server;

[PrimaryKey(nameof(UserUnitDeckSlotId))]
public class UserUnitDeckSlot
{
    public int UserUnitDeckSlotId { get; set; }

    public int UserUnitDeckId { get; set; }
    public int Position { get; set; }
    public int UnitOwningUserId { get; set; }

    public virtual UnitOwning UnitOwningUser { get; set; }
    public virtual UserUnitDeck UserUnitDeck { get; set; }
}