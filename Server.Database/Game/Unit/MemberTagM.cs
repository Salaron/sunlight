using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("member_tag_m")]
public partial class MemberTagM
{
    [Key]
    [Column("member_tag_id")]
    public int MemberTagId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("img_asset")]
    public string ImgAsset { get; set; }

    [Column("img_asset_en")]
    public string ImgAssetEn { get; set; }

    [Column("display_flag")]
    public int DisplayFlag { get; set; }

    [Column("num_of_members")]
    public int? NumOfMembers { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
