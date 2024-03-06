using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_base_touch_voice_m")]
public partial class UnitBaseTouchVoiceM
{
    [Key]
    [Column("unit_base_touch_voice_id")]
    public int UnitBaseTouchVoiceId { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

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

    [Column("min_rarity")]
    public int MinRarity { get; set; }
}
