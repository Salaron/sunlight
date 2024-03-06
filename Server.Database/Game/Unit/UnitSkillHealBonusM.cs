using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_skill_heal_bonus_m")]
public partial class UnitSkillHealBonusM
{
    [Key]
    [Column("total_hp")]
    public int TotalHp { get; set; }

    [Column("bonus_rate")]
    public double BonusRate { get; set; }
}
