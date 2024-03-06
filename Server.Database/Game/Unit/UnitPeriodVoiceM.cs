using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_period_voice_m")]
public partial class UnitPeriodVoiceM
{
    [Key]
    [Column("unit_period_voice_id")]
    public int UnitPeriodVoiceId { get; set; }

    [Column("unit_type_id")]
    public int? UnitTypeId { get; set; }

    [Column("unit_id")]
    public int? UnitId { get; set; }

    [Column("unit_status")]
    public int UnitStatus { get; set; }

    [Column("month_from")]
    public int MonthFrom { get; set; }

    [Column("day_from")]
    public int DayFrom { get; set; }

    [Column("month_to")]
    public int MonthTo { get; set; }

    [Column("day_to")]
    public int DayTo { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
