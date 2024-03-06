using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("album_series_m")]
public partial class AlbumSeriesM
{
    [Key]
    [Column("album_series_id")]
    public int AlbumSeriesId { get; set; }

    [Column("album_group_id")]
    public int AlbumGroupId { get; set; }

    [Column("album_tab_id")]
    public int AlbumTabId { get; set; }

    [Column("order_num")]
    public int OrderNum { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("layout_type")]
    public int LayoutType { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
