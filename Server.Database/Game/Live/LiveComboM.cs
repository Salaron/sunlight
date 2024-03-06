using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_combo_m")]
public partial class LiveComboM
{
    [Key]
    [Column("combo_cnt")]
    public int ComboCnt { get; set; }

    [Column("score_rate")]
    public double ScoreRate { get; set; }

    [Column("add_love_cnt")]
    public int AddLoveCnt { get; set; }
}
