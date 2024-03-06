using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("change_delegate_item_m")]
public partial class ChangeDelegateItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Column("rarity")]
    public int Rarity { get; set; }
}
