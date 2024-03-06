using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_special_m")]
public partial class AccessorySpecialM
{
    [Key]
    [Column("accessory_id")]
    public int AccessoryId { get; set; }

    [Column("unit_id")]
    public int UnitId { get; set; }
}
