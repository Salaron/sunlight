using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("unit_enhance_item_m")]
public partial class UnitEnhanceItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("unit_id")]
    public int? UnitId { get; set; }

    [Column("rarity")]
    public int? Rarity { get; set; }

    [Column("enhance_type")]
    public int EnhanceType { get; set; }

    [Column("enhance_amount")]
    public int EnhanceAmount { get; set; }
}
