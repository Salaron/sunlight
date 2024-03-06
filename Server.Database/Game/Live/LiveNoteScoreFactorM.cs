using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[PrimaryKey("EffectId", "Difficulty")]
[Table("live_note_score_factor_m")]
public partial class LiveNoteScoreFactorM
{
    [Key]
    [Column("effect_id")]
    public int EffectId { get; set; }

    [Key]
    [Column("difficulty")]
    public int Difficulty { get; set; }

    [Column("score_factor")]
    public double ScoreFactor { get; set; }
}
