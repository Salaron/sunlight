using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("live_time_m")]
public partial class LiveTimeM
{
    [Key]
    [Column("live_track_id")]
    public int LiveTrackId { get; set; }

    [Column("live_time")]
    public double LiveTime { get; set; }
}
