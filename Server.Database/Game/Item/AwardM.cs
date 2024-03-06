using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("award_m")]
public partial class AwardM
{
    [Key]
    [Column("award_id")]
    public int AwardId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Required]
    [Column("description")]
    public string Description { get; set; }

    [Column("description_en")]
    public string DescriptionEn { get; set; }

    [Required]
    [Column("img_asset")]
    public string ImgAsset { get; set; }

    [Column("img_asset_en")]
    public string ImgAssetEn { get; set; }

    [Column("sort")]
    public int Sort { get; set; }

    [Column("di_asset_display_flag")]
    public int DiAssetDisplayFlag { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
