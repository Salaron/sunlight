using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_skill_control_m")]
public partial class UnitSkillControlM
{
    [Key]
    [Column("unit_skill_control_id")]
    public int UnitSkillControlId { get; set; }

    [Column("combo_bonus")]
    public double ComboBonus { get; set; }

    [Column("combo_bonus_fixed")]
    public int ComboBonusFixed { get; set; }

    [Column("perfect_bonus")]
    public double PerfectBonus { get; set; }

    [Column("perfect_bonus_fixed")]
    public int PerfectBonusFixed { get; set; }

    [Column("totally_perfect_bonus")]
    public double TotallyPerfectBonus { get; set; }

    [Column("max_heal_bonus")]
    public int MaxHealBonus { get; set; }
}
