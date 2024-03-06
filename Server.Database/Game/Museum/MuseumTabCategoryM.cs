using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Museum;

[Table("museum_tab_category_m")]
public partial class MuseumTabCategoryM
{
    [Key]
    [Column("museum_tab_category_id")]
    public int MuseumTabCategoryId { get; set; }

    [Column("museum_tab_id")]
    public int MuseumTabId { get; set; }

    [Required]
    [Column("category_name")]
    public string CategoryName { get; set; }

    [Column("category_name_en")]
    public string CategoryNameEn { get; set; }

    [Column("master_type")]
    public int MasterType { get; set; }

    [Column("sort_id")]
    public int SortId { get; set; }
}
