using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_removable_skill_exchange_m")]
public partial class UnitRemovableSkillExchangeM
{
    [Key]
    [Column("unit_removable_skill_id")]
    public int UnitRemovableSkillId { get; set; }

    [Column("next_unit_removable_skill_id")]
    public int NextUnitRemovableSkillId { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("game_coin_amount")]
    public int GameCoinAmount { get; set; }
}
