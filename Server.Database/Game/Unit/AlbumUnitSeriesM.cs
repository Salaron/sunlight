using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("album_unit_series_m")]
public partial class AlbumUnitSeriesM
{
    [Key]
    [Column("album_unit_series_id")]
    public int AlbumUnitSeriesId { get; set; }

    [Column("album_series_id")]
    public int AlbumSeriesId { get; set; }

    [Column("unit_id")]
    public int? UnitId { get; set; }

    [Column("position")]
    public int Position { get; set; }

    [Column("release_date")]
    public string ReleaseDate { get; set; }
}
