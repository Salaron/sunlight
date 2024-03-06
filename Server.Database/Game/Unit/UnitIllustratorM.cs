using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_illustrator_m")]
public partial class UnitIllustratorM
{
    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }

    [Required]
    [Column("illustrator_asset")]
    public string IllustratorAsset { get; set; }

    [Column("illustrator_asset_en")]
    public string IllustratorAssetEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
