using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_track_m")]
public partial class LiveTrackM
{
    [Key]
    [Column("live_track_id")]
    public int LiveTrackId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Required]
    [Column("name_kana")]
    public string NameKana { get; set; }

    [Column("name_kana_en")]
    public string NameKanaEn { get; set; }

    [Required]
    [Column("title_asset")]
    public string TitleAsset { get; set; }

    [Column("title_asset_en")]
    public string TitleAssetEn { get; set; }

    [Required]
    [Column("sound_asset")]
    public string SoundAsset { get; set; }

    [Column("member_category")]
    public int MemberCategory { get; set; }

    [Column("member_tag_id")]
    public int MemberTagId { get; set; }

    [Column("unit_type_id")]
    public int? UnitTypeId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
