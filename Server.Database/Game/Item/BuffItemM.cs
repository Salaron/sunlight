using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("buff_item_m")]
public partial class BuffItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("buff_type")]
    public int BuffType { get; set; }

    [Column("buff_logic")]
    public int BuffLogic { get; set; }

    [Column("buff_amount")]
    public int BuffAmount { get; set; }

    [Column("limit_logic")]
    public int LimitLogic { get; set; }

    [Column("limit_amount")]
    public int LimitAmount { get; set; }

    [Column("event_id")]
    public int? EventId { get; set; }
}
