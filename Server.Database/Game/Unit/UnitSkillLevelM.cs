using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitSkillId", "SkillLevel")]
[Table("unit_skill_level_m")]
public partial class UnitSkillLevelM
{
    [Key]
    [Column("unit_skill_id")]
    public int UnitSkillId { get; set; }

    [Key]
    [Column("skill_level")]
    public int SkillLevel { get; set; }

    [Column("effect_range")]
    public int? EffectRange { get; set; }

    [Column("effect_value")]
    public double EffectValue { get; set; }

    [Column("discharge_time")]
    public double DischargeTime { get; set; }

    [Column("trigger_value")]
    public int TriggerValue { get; set; }

    [Column("trigger_limit")]
    public int? TriggerLimit { get; set; }

    [Column("activation_rate")]
    public int ActivationRate { get; set; }

    [Column("unit_skill_combo_pattern_id")]
    public int? UnitSkillComboPatternId { get; set; }

    [Column("spark_count_limit")]
    public int? SparkCountLimit { get; set; }

    [Column("grant_exp")]
    public int GrantExp { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
