using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_sign_asset_m")]
public partial class UnitSignAssetM
{
    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("normal_card_id")]
    public int NormalCardId { get; set; }

    [Column("rank_max_card_id")]
    public int RankMaxCardId { get; set; }

    [Required]
    [Column("normal_icon_asset")]
    public string NormalIconAsset { get; set; }

    [Column("normal_icon_asset_en")]
    public string NormalIconAssetEn { get; set; }

    [Required]
    [Column("rank_max_icon_asset")]
    public string RankMaxIconAsset { get; set; }

    [Column("rank_max_icon_asset_en")]
    public string RankMaxIconAssetEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
