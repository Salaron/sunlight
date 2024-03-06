using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[PrimaryKey("AddType", "ItemId")]
[Table("item_expire_m")]
public partial class ItemExpireM
{
    [Key]
    [Column("add_type")]
    public int AddType { get; set; }

    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Required]
    [Column("expire_date")]
    public string ExpireDate { get; set; }
}
