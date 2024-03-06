using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("sd_char_m")]
public partial class SdCharM
{
    [Key]
    [Column("sd_char_id")]
    public int SdCharId { get; set; }

    [Required]
    [Column("img_asset")]
    public string ImgAsset { get; set; }

    [Column("member_category_id")]
    public int MemberCategoryId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
