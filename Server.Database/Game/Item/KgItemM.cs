using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("kg_item_m")]
[Index("ItemCategoryId", Name = "idx_category_id")]
public partial class KgItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("item_tab_id")]
    public int ItemTabId { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("item_category_id")]
    public int? ItemCategoryId { get; set; }

    [Column("item_sub_category_id")]
    public int? ItemSubCategoryId { get; set; }

    [Column("effect_value")]
    public int? EffectValue { get; set; }

    [Column("image_asset")]
    public string ImageAsset { get; set; }

    [Column("image_asset_en")]
    public string ImageAssetEn { get; set; }

    [Column("icon_image_asset")]
    public string IconImageAsset { get; set; }

    [Column("icon_image_asset_en")]
    public string IconImageAssetEn { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("description_en")]
    public string DescriptionEn { get; set; }

    [Column("rank")]
    public int? Rank { get; set; }

    [Column("enhancement_exp_id")]
    public int? EnhancementExpId { get; set; }

    [Column("enhancement_pattern_id")]
    public int? EnhancementPatternId { get; set; }

    [Column("merchandise_group_id")]
    public int? MerchandiseGroupId { get; set; }

    [Column("merchandise_flag")]
    public int MerchandiseFlag { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
