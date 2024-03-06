using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("multi_unit_asset_m")]
public partial class MultiUnitAssetM
{
    [Key]
    [Column("multi_unit_id")]
    public int MultiUnitId { get; set; }

    [Required]
    [Column("still_asset")]
    public string StillAsset { get; set; }

    [Column("still_asset_en")]
    public string StillAssetEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
