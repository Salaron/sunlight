using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_m")]
public partial class AccessoryM
{
    [Key]
    [Column("accessory_id")]
    public int AccessoryId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("rarity")]
    public int Rarity { get; set; }

    [Column("smile_max")]
    public int? SmileMax { get; set; }

    [Column("pure_max")]
    public int? PureMax { get; set; }

    [Column("cool_max")]
    public int? CoolMax { get; set; }

    [Column("is_material")]
    public int IsMaterial { get; set; }

    [Column("effect_type")]
    public int? EffectType { get; set; }

    [Column("default_max_level")]
    public int? DefaultMaxLevel { get; set; }

    [Column("max_level")]
    public int? MaxLevel { get; set; }

    [Column("accessory_asset_id")]
    public int AccessoryAssetId { get; set; }

    [Column("trigger_type")]
    public int? TriggerType { get; set; }

    [Column("trigger_effect_type")]
    public int? TriggerEffectType { get; set; }

    [Column("open_date")]
    public string OpenDate { get; set; }
}
