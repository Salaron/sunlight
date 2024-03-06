using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("skill_effect_type_m")]
public partial class SkillEffectTypeM
{
    [Column("id")]
    public int? Id { get; set; }

    [Key]
    [Column("skill_effect_type")]
    public int SkillEffectType { get; set; }

    [Required]
    [Column("type_name")]
    public string TypeName { get; set; }

    [Column("type_name_en")]
    public string TypeNameEn { get; set; }

    [Column("notes_no")]
    public int? NotesNo { get; set; }

    [Column("bonus_type")]
    public int BonusType { get; set; }
}
