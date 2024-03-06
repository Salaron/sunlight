using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitSkillLevelUpPatternId", "SkillLevel")]
[Table("unit_skill_level_up_pattern_m")]
public partial class UnitSkillLevelUpPatternM
{
    [Key]
    [Column("unit_skill_level_up_pattern_id")]
    public int UnitSkillLevelUpPatternId { get; set; }

    [Key]
    [Column("skill_level")]
    public int SkillLevel { get; set; }

    [Column("next_exp")]
    public int NextExp { get; set; }
}
