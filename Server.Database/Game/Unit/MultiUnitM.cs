using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("MultiUnitId", "UnitId")]
[Table("multi_unit_m")]
public partial class MultiUnitM
{
    [Key]
    [Column("multi_unit_id")]
    public int MultiUnitId { get; set; }

    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }
}
