using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_leader_skill_m")]
public partial class UnitLeaderSkillM
{
    [Key]
    [Column("unit_leader_skill_id")]
    public int UnitLeaderSkillId { get; set; }

    [Column("leader_skill_effect_type")]
    public int LeaderSkillEffectType { get; set; }

    [Column("effect_value")]
    public int EffectValue { get; set; }

    [Column("name_string_key")]
    public string NameStringKey { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
