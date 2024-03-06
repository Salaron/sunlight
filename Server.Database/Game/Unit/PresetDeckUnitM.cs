using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("PresetDeckId", "Position")]
[Table("preset_deck_unit_m")]
public partial class PresetDeckUnitM
{
    [Key]
    [Column("preset_deck_id")]
    public int PresetDeckId { get; set; }

    [Key]
    [Column("position")]
    public int Position { get; set; }

    [Column("is_replace_unit")]
    public int IsReplaceUnit { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("exp")]
    public int Exp { get; set; }

    [Column("level")]
    public int Level { get; set; }

    [Column("love")]
    public int Love { get; set; }

    [Column("unit_skill_exp")]
    public int UnitSkillExp { get; set; }

    [Column("unit_skill_level")]
    public int UnitSkillLevel { get; set; }

    [Column("max_hp")]
    public int MaxHp { get; set; }

    [Column("unit_removable_skill_capacity")]
    public int? UnitRemovableSkillCapacity { get; set; }

    [Column("is_rank_max")]
    public int IsRankMax { get; set; }

    [Column("is_level_max")]
    public int IsLevelMax { get; set; }

    [Column("is_love_max")]
    public int IsLoveMax { get; set; }
}
