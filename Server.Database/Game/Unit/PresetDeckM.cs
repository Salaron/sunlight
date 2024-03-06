using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("preset_deck_m")]
public partial class PresetDeckM
{
    [Key]
    [Column("preset_deck_id")]
    public int PresetDeckId { get; set; }

    [Required]
    [Column("deck_name")]
    public string DeckName { get; set; }

    [Column("deck_name_en")]
    public string DeckNameEn { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
