using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_base_time_voice_m")]
public partial class UnitBaseTimeVoiceM
{
    [Key]
    [Column("unit_base_time_voice_id")]
    public int UnitBaseTimeVoiceId { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

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

    [Column("min_rarity")]
    public int MinRarity { get; set; }
}
