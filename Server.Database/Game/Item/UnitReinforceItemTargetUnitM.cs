using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[PrimaryKey("ItemId", "UnitId")]
[Table("unit_reinforce_item_target_unit_m")]
public partial class UnitReinforceItemTargetUnitM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }
}
