using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;

namespace Server.Database.Server;

[PrimaryKey(nameof(Id))]
public class RewardBoxItem
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AddType AddType { get; set; }
    public int? ItemId { get; set; }
    public int Amount { get; set; }
    public string Message { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime InsertDate { get; set; }

    public DateTime? OpenDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public virtual User User { get; set; }
}