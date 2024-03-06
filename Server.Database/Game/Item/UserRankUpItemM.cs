using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("user_rank_up_item_m")]
public partial class UserRankUpItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("use_limit_rank")]
    public int? UseLimitRank { get; set; }

    [Column("use_limit_rank_min")]
    public int? UseLimitRankMin { get; set; }
}
