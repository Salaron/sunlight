using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[PrimaryKey("LiveNotesIconId", "TapType", "AttributeId")]
[Table("live_notes_icon_asset_m")]
public partial class LiveNotesIconAssetM
{
    [Key]
    [Column("live_notes_icon_id")]
    public int LiveNotesIconId { get; set; }

    [Key]
    [Column("tap_type")]
    public int TapType { get; set; }

    [Key]
    [Column("attribute_id")]
    public int AttributeId { get; set; }

    [Required]
    [Column("icon_asset")]
    public string IconAsset { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
