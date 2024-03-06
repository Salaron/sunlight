using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("hidden_unit_setting_m")]
public partial class HiddenUnitSettingM
{
    [Key]
    [Column("hidden_unit_setting_id")]
    public int HiddenUnitSettingId { get; set; }

    [Column("hidden_unit_id")]
    public int HiddenUnitId { get; set; }

    [Column("live_category")]
    public int LiveCategory { get; set; }

    [Column("start_date")]
    public string StartDate { get; set; }

    [Column("end_date")]
    public string EndDate { get; set; }
}
