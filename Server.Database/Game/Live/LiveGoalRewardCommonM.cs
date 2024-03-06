using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_goal_reward_common_m")]
public partial class LiveGoalRewardCommonM
{
    [Key]
    [Column("live_goal_reward_common_id")]
    public int LiveGoalRewardCommonId { get; set; }

    [Column("live_type")]
    public int LiveType { get; set; }

    [Column("difficulty")]
    public int Difficulty { get; set; }

    [Column("live_goal_type")]
    public int LiveGoalType { get; set; }

    [Column("rank")]
    public int Rank { get; set; }

    [Column("add_type")]
    public int AddType { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("item_category_id")]
    public int? ItemCategoryId { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("item_option")]
    public string ItemOption { get; set; }
}
