using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_time_voice_m")]
public partial class UnitTimeVoiceM
{
    [Key]
    [Column("unit_time_voice_id")]
    public int UnitTimeVoiceId { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("unit_status")]
    public int UnitStatus { get; set; }

    [Required]
    [Column("time_from")]
    public string TimeFrom { get; set; }

    [Column("time_from_en")]
    public string TimeFromEn { get; set; }

    [Required]
    [Column("time_to")]
    public string TimeTo { get; set; }

    [Column("time_to_en")]
    public string TimeToEn { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
