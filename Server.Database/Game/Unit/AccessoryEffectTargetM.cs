using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("AccessoryId", "ReferenceType", "EffectTarget")]
[Table("accessory_effect_target_m")]
public partial class AccessoryEffectTargetM
{
    [Key]
    [Column("accessory_id")]
    public int AccessoryId { get; set; }

    [Key]
    [Column("reference_type")]
    public int ReferenceType { get; set; }

    [Key]
    [Column("effect_target")]
    public int EffectTarget { get; set; }
}
