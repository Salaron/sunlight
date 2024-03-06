using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_touch_voice_m")]
public partial class UnitTouchVoiceM
{
    [Key]
    [Column("unit_touch_voice_id")]
    public int UnitTouchVoiceId { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("unit_status")]
    public int UnitStatus { get; set; }

    [Column("from_x")]
    public int FromX { get; set; }

    [Column("from_y")]
    public int FromY { get; set; }

    [Column("to_x")]
    public int ToX { get; set; }

    [Column("to_y")]
    public int ToY { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
