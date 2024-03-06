using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("MemberCategory", "UnitTypeId")]
[Table("unit_type_series_m")]
public partial class UnitTypeSeriesM
{
    [Key]
    [Column("member_category")]
    public int MemberCategory { get; set; }

    [Key]
    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }
}
