using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Museum;

[Table("museum_menu_m")]
public partial class MuseumMenuM
{
    [Key]
    [Column("museum_menu_id")]
    public int MuseumMenuId { get; set; }

    [Required]
    [Column("menu_asset")]
    public string MenuAsset { get; set; }

    [Column("menu_asset_en")]
    public string MenuAssetEn { get; set; }

    [Column("sort_id")]
    public int SortId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
