using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("item_exchange_m")]
public partial class ItemExchangeM
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("next_item_id")]
    public int NextItemId { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("game_coin_amount")]
    public int GameCoinAmount { get; set; }
}
