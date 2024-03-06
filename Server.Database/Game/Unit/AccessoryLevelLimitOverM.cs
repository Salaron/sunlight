using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("BaseRarity", "MaterialRarity")]
[Table("accessory_level_limit_over_m")]
public partial class AccessoryLevelLimitOverM
{
    [Key]
    [Column("base_rarity")]
    public int BaseRarity { get; set; }

    [Key]
    [Column("material_rarity")]
    public int MaterialRarity { get; set; }

    [Column("amount")]
    public int Amount { get; set; }
}
