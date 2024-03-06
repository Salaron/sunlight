using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_removable_skill_live_effect_m")]
public partial class UnitRemovableSkillLiveEffectM
{
    [Key]
    [Column("unit_removable_skill_id")]
    public int UnitRemovableSkillId { get; set; }

    [Column("effect_type")]
    public int EffectType { get; set; }

    [Column("effect_interval")]
    public double? EffectInterval { get; set; }

    [Column("trigger_type")]
    public int TriggerType { get; set; }

    [Column("trigger_value")]
    public int TriggerValue { get; set; }
}
