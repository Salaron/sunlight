using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("free_live_m")]
public partial class FreeLiveM
{
    [Key]
    [Column("live_difficulty_id")]
    public int LiveDifficultyId { get; set; }

    [Column("live_setting_id")]
    public int LiveSettingId { get; set; }

    [Column("random_flag")]
    public int RandomFlag { get; set; }
}
