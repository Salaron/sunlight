using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitLevelUpPatternId", "UnitLevel")]
[Table("unit_level_up_pattern_m")]
public partial class UnitLevelUpPatternM
{
    [Key]
    [Column("unit_level_up_pattern_id")]
    public int UnitLevelUpPatternId { get; set; }

    [Key]
    [Column("unit_level")]
    public int UnitLevel { get; set; }

    [Column("next_exp")]
    public int NextExp { get; set; }

    [Column("hp_diff")]
    public int HpDiff { get; set; }

    [Column("smile_diff")]
    public int SmileDiff { get; set; }

    [Column("pure_diff")]
    public int PureDiff { get; set; }

    [Column("cool_diff")]
    public int CoolDiff { get; set; }

    [Column("merge_exp")]
    public int MergeExp { get; set; }

    [Column("merge_cost")]
    public int MergeCost { get; set; }

    [Column("sale_price")]
    public int SalePrice { get; set; }
}
