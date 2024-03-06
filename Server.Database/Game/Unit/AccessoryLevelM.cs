using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("AccessoryId", "Level")]
[Table("accessory_level_m")]
public partial class AccessoryLevelM
{
    [Key]
    [Column("accessory_id")]
    public int AccessoryId { get; set; }

    [Key]
    [Column("level")]
    public int Level { get; set; }

    [Column("next_exp")]
    public int NextExp { get; set; }

    [Column("effect_range")]
    public int? EffectRange { get; set; }

    [Column("effect_value")]
    public double EffectValue { get; set; }

    [Column("discharge_time")]
    public double DischargeTime { get; set; }

    [Column("trigger_value")]
    public int? TriggerValue { get; set; }

    [Column("activation_rate")]
    public int ActivationRate { get; set; }

    [Column("unit_skill_combo_pattern_id")]
    public int? UnitSkillComboPatternId { get; set; }

    [Column("spark_count_limit")]
    public int? SparkCountLimit { get; set; }

    [Column("smile_diff")]
    public int? SmileDiff { get; set; }

    [Column("pure_diff")]
    public int? PureDiff { get; set; }

    [Column("cool_diff")]
    public int? CoolDiff { get; set; }

    [Column("grant_exp")]
    public int GrantExp { get; set; }

    [Column("merge_cost")]
    public int MergeCost { get; set; }

    [Column("sale_price")]
    public int SalePrice { get; set; }
}
