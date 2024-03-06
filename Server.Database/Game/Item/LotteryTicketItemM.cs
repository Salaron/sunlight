using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("lottery_ticket_item_m")]
public partial class LotteryTicketItemM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("lottery_ticket_id")]
    public int LotteryTicketId { get; set; }
}
