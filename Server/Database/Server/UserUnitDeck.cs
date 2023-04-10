using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

[PrimaryKey(nameof(UserUnitDeckId))]
public class UserUnitDeck
{
    public int UserUnitDeckId { get; set; }

    public string DeckName { get; set; }
    public bool MainFlag => true;
    public int UnitDeckId { get; set; }
    public int UserId { get; set; }

    public virtual List<UserUnitDeckSlot> UnitOwningUserIds { get; set; }
    public virtual User User { get; set; }
}