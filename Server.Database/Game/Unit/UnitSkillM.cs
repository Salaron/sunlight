using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_skill_m")]
public partial class UnitSkillM
{
    [Key]
    [Column("unit_skill_id")]
    public int UnitSkillId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("max_level")]
    public int MaxLevel { get; set; }

    [Column("skill_effect_type")]
    public int SkillEffectType { get; set; }

    [Column("discharge_type")]
    public int DischargeType { get; set; }

    [Column("trigger_type")]
    public int TriggerType { get; set; }

    [Column("trigger_effect_type")]
    public int? TriggerEffectType { get; set; }

    [Column("unit_skill_level_up_pattern_id")]
    public int UnitSkillLevelUpPatternId { get; set; }

    [Column("string_key_trigger")]
    public string StringKeyTrigger { get; set; }

    [Column("string_key_effect")]
    public string StringKeyEffect { get; set; }

    [Column("string_key_long_description")]
    public string StringKeyLongDescription { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
