using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_base_function_voice_m")]
public partial class UnitBaseFunctionVoiceM
{
    [Key]
    [Column("unit_base_function_voice_id")]
    public int UnitBaseFunctionVoiceId { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

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
