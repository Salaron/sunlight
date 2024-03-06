using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("unit_reinforce_item_m")]
public partial class UnitReinforceItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("reinforce_type")]
    public int ReinforceType { get; set; }

    [Column("addition_value")]
    public int AdditionValue { get; set; }

    [Column("event_id")]
    public int? EventId { get; set; }
}
