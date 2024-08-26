using Microsoft.EntityFrameworkCore;

namespace Server.Database.Server;

[PrimaryKey(nameof(Id))]
public class LoginBonus
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateOnly Date { get; set; }
    
    public virtual User User { get; set; }
}