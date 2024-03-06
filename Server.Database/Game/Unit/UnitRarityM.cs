using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_rarity_m")]
public partial class UnitRarityM
{
    [Key]
    [Column("rarity")]
    public int Rarity { get; set; }

    [Column("before_love_max")]
    public int BeforeLoveMax { get; set; }

    [Column("after_love_max")]
    public int AfterLoveMax { get; set; }

    [Column("before_level_max")]
    public int BeforeLevelMax { get; set; }

    [Column("after_level_max")]
    public int AfterLevelMax { get; set; }

    [Column("rank_up_cost")]
    public int RankUpCost { get; set; }

    [Column("exchange_point_rank_up_cost")]
    public int ExchangePointRankUpCost { get; set; }

    [Column("sort")]
    public int Sort { get; set; }

    [Column("costume_level_limit")]
    public int CostumeLevelLimit { get; set; }
}
