using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("recovery_item_m")]
public partial class RecoveryItemM
{
    [Key]
    [Column("recovery_item_id")]
    public int RecoveryItemId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("recovery_type")]
    public int RecoveryType { get; set; }

    [Column("recovery_value")]
    public int RecoveryValue { get; set; }

    [Column("small_asset")]
    public string SmallAsset { get; set; }

    [Column("small_asset_en")]
    public string SmallAssetEn { get; set; }

    [Column("middle_asset")]
    public string MiddleAsset { get; set; }

    [Column("middle_asset_en")]
    public string MiddleAssetEn { get; set; }

    [Column("large_asset")]
    public string LargeAsset { get; set; }

    [Column("large_asset_en")]
    public string LargeAssetEn { get; set; }

    [Required]
    [Column("description")]
    public string Description { get; set; }

    [Column("description_en")]
    public string DescriptionEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
