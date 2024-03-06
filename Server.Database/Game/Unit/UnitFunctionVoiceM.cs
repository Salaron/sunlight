using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_function_voice_m")]
public partial class UnitFunctionVoiceM
{
    [Key]
    [Column("unit_function_voice_id")]
    public int UnitFunctionVoiceId { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("unit_status")]
    public int UnitStatus { get; set; }

    [Column("function_id")]
    public int FunctionId { get; set; }

    [Column("function_type")]
    public int FunctionType { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
