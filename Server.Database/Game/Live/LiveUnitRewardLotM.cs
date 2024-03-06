using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_unit_reward_lot_m")]
public partial class LiveUnitRewardLotM
{
    [Key]
    [Column("live_unit_reward_lot_id")]
    public int LiveUnitRewardLotId { get; set; }

    [Column("difficulty")]
    public int Difficulty { get; set; }

    [Column("condition_type")]
    public int ConditionType { get; set; }

    [Column("rank")]
    public int? Rank { get; set; }

    [Column("live_unit_reward_group_id")]
    public int LiveUnitRewardGroupId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }
}
