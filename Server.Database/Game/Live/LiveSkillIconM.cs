using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_skill_icon_m")]
public partial class LiveSkillIconM
{
    [Key]
    [Column("skill_effect_type")]
    public int SkillEffectType { get; set; }

    [Required]
    [Column("icon_asset")]
    public string IconAsset { get; set; }

    [Column("icon_asset_en")]
    public string IconAssetEn { get; set; }

    [Column("icon_order")]
    public int IconOrder { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
