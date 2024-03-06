using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_removable_skill_m")]
public partial class UnitRemovableSkillM
{
    [Key]
    [Column("unit_removable_skill_id")]
    public int UnitRemovableSkillId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("skill_type")]
    public int SkillType { get; set; }

    [Column("unit_rarity")]
    public int? UnitRarity { get; set; }

    [Column("level")]
    public int Level { get; set; }

    [Required]
    [Column("icon_asset")]
    public string IconAsset { get; set; }

    [Column("icon_asset_en")]
    public string IconAssetEn { get; set; }

    [Column("small_icon_asset")]
    public string SmallIconAsset { get; set; }

    [Column("small_icon_asset_en")]
    public string SmallIconAssetEn { get; set; }

    [Column("middle_icon_asset")]
    public string MiddleIconAsset { get; set; }

    [Column("middle_icon_asset_en")]
    public string MiddleIconAssetEn { get; set; }

    [Required]
    [Column("bond_asset")]
    public string BondAsset { get; set; }

    [Column("bond_asset_en")]
    public string BondAssetEn { get; set; }

    [Column("size")]
    public int Size { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("description_en")]
    public string DescriptionEn { get; set; }

    [Column("effect_range")]
    public int EffectRange { get; set; }

    [Column("effect_type")]
    public int EffectType { get; set; }

    [Column("effect_value")]
    public double EffectValue { get; set; }

    [Column("fixed_value_flag")]
    public int FixedValueFlag { get; set; }

    [Column("target_reference_type")]
    public int TargetReferenceType { get; set; }

    [Column("target_type")]
    public int TargetType { get; set; }

    [Column("trigger_reference_type")]
    public int TriggerReferenceType { get; set; }

    [Column("trigger_type")]
    public int TriggerType { get; set; }

    [Column("sub_skill_id")]
    public int? SubSkillId { get; set; }

    [Column("selling_price")]
    public int SellingPrice { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
