using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_lottery_cost_m")]
public partial class AccessoryLotteryCostM
{
    [Key]
    [Column("accessory_lottery_cost_id")]
    public int AccessoryLotteryCostId { get; set; }

    [Column("status_type")]
    public int StatusType { get; set; }

    [Column("from_value")]
    public int FromValue { get; set; }

    [Column("to_value")]
    public int ToValue { get; set; }

    [Column("cost_value")]
    public int CostValue { get; set; }
}
