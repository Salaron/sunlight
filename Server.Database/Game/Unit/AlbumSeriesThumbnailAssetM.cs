using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("AlbumSeriesId", "StartDate")]
[Table("album_series_thumbnail_asset_m")]
public partial class AlbumSeriesThumbnailAssetM
{
    [Key]
    [Column("album_series_id")]
    public int AlbumSeriesId { get; set; }

    [Key]
    [Column("start_date")]
    public string StartDate { get; set; }

    [Required]
    [Column("thumbnail_asset")]
    public string ThumbnailAsset { get; set; }

    [Column("thumbnail_asset_en")]
    public string ThumbnailAssetEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
