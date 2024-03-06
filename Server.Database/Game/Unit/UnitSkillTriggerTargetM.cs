using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitSkillId", "ReferenceType", "TriggerTarget")]
[Table("unit_skill_trigger_target_m")]
public partial class UnitSkillTriggerTargetM
{
    [Key]
    [Column("unit_skill_id")]
    public int UnitSkillId { get; set; }

    [Key]
    [Column("reference_type")]
    public int ReferenceType { get; set; }

    [Key]
    [Column("trigger_target")]
    public int TriggerTarget { get; set; }
}
