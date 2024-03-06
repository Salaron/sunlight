using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_birthday_voice_m")]
public partial class UnitBirthdayVoiceM
{
    [Key]
    [Column("unit_birthday_voice_id")]
    public int UnitBirthdayVoiceId { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
