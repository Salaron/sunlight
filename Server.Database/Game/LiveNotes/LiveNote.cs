using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.LiveNotes;

[Table("live_notes")]
public partial class LiveNote
{
    [Key]
    [Column("notes_setting_asset")]
    public string NotesSettingAsset { get; set; }

    [Required]
    [Column("json")]
    public string Json { get; set; }
}
