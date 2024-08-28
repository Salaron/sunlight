using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Server;

[PrimaryKey(nameof(UserItemId))]
public class UserItems
{
    public int UserItemId { get; set; }
    public int UserId { get; set; }
    public int ItemType { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime InsertDate { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdateDate { get; set; }
    
    public virtual User User { get; set; }
}