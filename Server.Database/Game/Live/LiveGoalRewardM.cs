using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_goal_reward_m")]
[Index("LiveDifficultyId", Name = "idx_live_difficulty_id")]
public partial class LiveGoalRewardM
{
    [Key]
    [Column("live_goal_reward_id")]
    public int LiveGoalRewardId { get; set; }

    [Column("live_difficulty_id")]
    public int LiveDifficultyId { get; set; }

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
