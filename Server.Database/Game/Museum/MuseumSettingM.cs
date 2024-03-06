using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Museum;

[Table("museum_setting_m")]
public partial class MuseumSettingM
{
    [Key]
    [Column("museum_setting_id")]
    public int MuseumSettingId { get; set; }

    [Required]
    [Column("start_date")]
    public string StartDate { get; set; }

    [Column("status_ver")]
    public int StatusVer { get; set; }
}
