using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_lottery_list_m")]
public partial class AccessoryLotteryListM
{
    [Key]
    [Column("accessory_lottery_list_id")]
    public int AccessoryLotteryListId { get; set; }

    [Column("accessory_lottery_group_id")]
    public int AccessoryLotteryGroupId { get; set; }

    [Column("accessory_id")]
    public int AccessoryId { get; set; }

    [Column("weight")]
    public int Weight { get; set; }

    [Column("start_date")]
    public string StartDate { get; set; }

    [Column("end_date")]
    public string EndDate { get; set; }
}
