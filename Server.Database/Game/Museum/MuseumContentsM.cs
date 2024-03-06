using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Museum;

[Table("museum_contents_m")]
public partial class MuseumContentsM
{
    [Key]
    [Column("museum_contents_id")]
    public int MuseumContentsId { get; set; }

    [Column("museum_tab_category_id")]
    public int MuseumTabCategoryId { get; set; }

    [Column("master_id")]
    public int? MasterId { get; set; }

    [Column("thumbnail_asset")]
    public string ThumbnailAsset { get; set; }

    [Column("thumbnail_asset_en")]
    public string ThumbnailAssetEn { get; set; }

    [Required]
    [Column("title")]
    public string Title { get; set; }

    [Column("title_en")]
    public string TitleEn { get; set; }

    [Required]
    [Column("category")]
    public string Category { get; set; }

    [Column("category_en")]
    public string CategoryEn { get; set; }

    [Column("museum_rarity")]
    public int MuseumRarity { get; set; }

    [Column("attribute_id")]
    public int AttributeId { get; set; }

    [Column("smile_buff")]
    public int SmileBuff { get; set; }

    [Column("pure_buff")]
    public int PureBuff { get; set; }

    [Column("cool_buff")]
    public int CoolBuff { get; set; }

    [Column("sort_id")]
    public int SortId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
