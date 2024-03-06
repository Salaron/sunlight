using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("normal_live_m")]
public partial class NormalLiveM
{
    [Key]
    [Column("live_difficulty_id")]
    public int LiveDifficultyId { get; set; }

    [Column("live_setting_id")]
    public int LiveSettingId { get; set; }

    [Column("capital_type")]
    public int CapitalType { get; set; }

    [Column("capital_value")]
    public int CapitalValue { get; set; }

    [Column("default_unlocked_flag")]
    public int DefaultUnlockedFlag { get; set; }

    [Column("c_rank_complete")]
    public int CRankComplete { get; set; }

    [Column("b_rank_complete")]
    public int BRankComplete { get; set; }

    [Column("a_rank_complete")]
    public int ARankComplete { get; set; }

    [Column("s_rank_complete")]
    public int SRankComplete { get; set; }
}
