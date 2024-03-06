using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[PrimaryKey("LiveSeId", "LiveSeAssetType")]
[Table("live_se_group_m")]
public partial class LiveSeGroupM
{
    [Key]
    [Column("live_se_id")]
    public int LiveSeId { get; set; }

    [Key]
    [Column("live_se_asset_type")]
    public int LiveSeAssetType { get; set; }

    [Required]
    [Column("se_asset")]
    public string SeAsset { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
