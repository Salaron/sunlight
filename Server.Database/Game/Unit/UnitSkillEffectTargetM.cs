using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitSkillId", "ReferenceType", "EffectTarget")]
[Table("unit_skill_effect_target_m")]
public partial class UnitSkillEffectTargetM
{
    [Key]
    [Column("unit_skill_id")]
    public int UnitSkillId { get; set; }

    [Key]
    [Column("reference_type")]
    public int ReferenceType { get; set; }

    [Key]
    [Column("effect_target")]
    public int EffectTarget { get; set; }
}
