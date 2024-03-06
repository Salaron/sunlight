using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("memories_m")]
public partial class MemoriesM
{
    [Key]
    [Column("memories_id")]
    public int MemoriesId { get; set; }

    [Required]
    [Column("img_asset")]
    public string ImgAsset { get; set; }

    [Column("background_shader_param_id")]
    public int? BackgroundShaderParamId { get; set; }

    [Column("background_flash_param_id")]
    public int? BackgroundFlashParamId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
