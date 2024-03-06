using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("HiddenUnitId", "UnitSkillId", "UnitSkillLevel")]
[Table("hidden_unit_skill_m")]
public partial class HiddenUnitSkillM
{
    [Key]
    [Column("hidden_unit_id")]
    public int HiddenUnitId { get; set; }

    [Key]
    [Column("unit_skill_id")]
    public int UnitSkillId { get; set; }

    [Key]
    [Column("unit_skill_level")]
    public int UnitSkillLevel { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
