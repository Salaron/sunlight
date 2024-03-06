using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_random_voice_m")]
public partial class UnitRandomVoiceM
{
    [Key]
    [Column("unit_random_voice_id")]
    public int UnitRandomVoiceId { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("unit_status")]
    public int UnitStatus { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
