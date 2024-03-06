using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_navi_asset_m")]
public partial class UnitNaviAssetM
{
    [Key]
    [Column("unit_navi_asset_id")]
    public int UnitNaviAssetId { get; set; }

    [Required]
    [Column("unit_navi_asset")]
    public string UnitNaviAsset { get; set; }

    [Column("unit_navi_asset_en")]
    public string UnitNaviAssetEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
