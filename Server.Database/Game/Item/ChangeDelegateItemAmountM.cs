using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[PrimaryKey("UnitRarity", "ItemRarity")]
[Table("change_delegate_item_amount_m")]
public partial class ChangeDelegateItemAmountM
{
    [Key]
    [Column("unit_rarity")]
    public int UnitRarity { get; set; }

    [Key]
    [Column("item_rarity")]
    public int ItemRarity { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("cost_game_coin_amount")]
    public int CostGameCoinAmount { get; set; }
}
