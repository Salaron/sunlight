using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_cutin_brightness_m")]
public partial class LiveCutinBrightnessM
{
    [Key]
    [Column("live_cutin_brightness_id")]
    public int LiveCutinBrightnessId { get; set; }

    [Column("brightness")]
    public int Brightness { get; set; }
}
