using Microsoft.EntityFrameworkCore;

namespace Server.Database.Server;

[PrimaryKey(nameof(UserUnitDeckId))]
public class UserUnitDeck
{
    public int UserUnitDeckId { get; set; }

    public string DeckName { get; set; }
    public bool MainFlag { get; set; }
    public int UnitDeckId { get; set; }
    public int UserId { get; set; }

    public virtual List<UserUnitDeckSlot> UnitDeckSlots { get; set; }
    public virtual User User { get; set; }
}