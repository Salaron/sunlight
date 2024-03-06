using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_description_m")]
public partial class AccessoryDescriptionM
{
    [Key]
    [Column("accessory_description_id")]
    public int AccessoryDescriptionId { get; set; }

    [Required]
    [Column("description_asset")]
    public string DescriptionAsset { get; set; }

    [Column("description_asset_en")]
    public string DescriptionAssetEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
