using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("background_flash_m")]
public partial class BackgroundFlashM
{
    [Key]
    [Column("background_flash_param_id")]
    public int BackgroundFlashParamId { get; set; }

    [Required]
    [Column("flash_asset")]
    public string FlashAsset { get; set; }

    [Required]
    [Column("movie_name")]
    public string MovieName { get; set; }

    [Required]
    [Column("start_frame")]
    public string StartFrame { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
