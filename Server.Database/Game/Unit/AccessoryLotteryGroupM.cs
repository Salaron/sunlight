using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_lottery_group_m")]
public partial class AccessoryLotteryGroupM
{
    [Key]
    [Column("accessory_lottery_group_id")]
    public int AccessoryLotteryGroupId { get; set; }

    [Column("from_cost")]
    public int FromCost { get; set; }

    [Column("to_cost")]
    public int ToCost { get; set; }
}
