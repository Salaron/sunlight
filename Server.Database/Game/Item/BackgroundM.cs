using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("background_m")]
public partial class BackgroundM
{
    [Key]
    [Column("background_id")]
    public int BackgroundId { get; set; }

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

    [Required]
    [Column("thumbnail_asset")]
    public string ThumbnailAsset { get; set; }

    [Column("sort")]
    public int Sort { get; set; }

    [Column("background_shader_param_id")]
    public int? BackgroundShaderParamId { get; set; }

    [Column("background_flash_param_id")]
    public int? BackgroundFlashParamId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
