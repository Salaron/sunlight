using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;

namespace Server.Database.Server;

[PrimaryKey(nameof(UserItemUnlockId))]
[Index(nameof(UserId), nameof(AddType), nameof(ItemId), IsUnique = true)]
public class UserItemUnlock
{
    public int UserItemUnlockId { get; set; }
    public int UserId { get; set; }
    public AddType AddType { get; set; }
    public int ItemId { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime InsertDate { get; set; }
}