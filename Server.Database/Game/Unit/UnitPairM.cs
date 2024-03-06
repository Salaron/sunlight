using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_pair_m")]
public partial class UnitPairM
{
    [Key]
    [Column("unit_pair_id")]
    public int UnitPairId { get; set; }

    [Column("pair")]
    public int Pair { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("position")]
    public int Position { get; set; }

    [Column("rank")]
    public int Rank { get; set; }
}
