using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Museum;

[Table("museum_tab_m")]
public partial class MuseumTabM
{
    [Key]
    [Column("museum_tab_id")]
    public int MuseumTabId { get; set; }

    [Column("museum_menu_id")]
    public int MuseumMenuId { get; set; }

    [Required]
    [Column("tab_name")]
    public string TabName { get; set; }

    [Column("tab_name_en")]
    public string TabNameEn { get; set; }

    [Column("sort_id")]
    public int SortId { get; set; }
}
