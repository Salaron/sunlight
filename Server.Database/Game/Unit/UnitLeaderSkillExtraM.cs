using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_leader_skill_extra_m")]
public partial class UnitLeaderSkillExtraM
{
    [Key]
    [Column("unit_leader_skill_id")]
    public int UnitLeaderSkillId { get; set; }

    [Column("member_tag_id")]
    public int MemberTagId { get; set; }

    [Column("leader_skill_effect_type")]
    public int LeaderSkillEffectType { get; set; }

    [Column("effect_value")]
    public int EffectValue { get; set; }
}
