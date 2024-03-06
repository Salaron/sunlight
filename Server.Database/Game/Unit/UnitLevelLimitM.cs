using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_level_limit_m")]
public partial class UnitLevelLimitM
{
    [Key]
    [Column("unit_level_limit_id")]
    public int UnitLevelLimitId { get; set; }

    [Column("unit_level_limit_group_id")]
    public int UnitLevelLimitGroupId { get; set; }

    [Column("enhanced_max_level")]
    public int EnhancedMaxLevel { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
