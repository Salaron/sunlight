using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_asset_m")]
public partial class AccessoryAssetM
{
    [Key]
    [Column("accessory_asset_id")]
    public int AccessoryAssetId { get; set; }

    [Required]
    [Column("icon_asset")]
    public string IconAsset { get; set; }

    [Column("small_icon_asset")]
    public string SmallIconAsset { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
