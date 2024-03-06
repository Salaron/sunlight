using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitSkillComboPatternId", "ComboCount")]
[Table("unit_skill_combo_pattern_m")]
public partial class UnitSkillComboPatternM
{
    [Key]
    [Column("unit_skill_combo_pattern_id")]
    public int UnitSkillComboPatternId { get; set; }

    [Key]
    [Column("combo_count")]
    public int ComboCount { get; set; }

    [Column("bonus_rate")]
    public double BonusRate { get; set; }
}
