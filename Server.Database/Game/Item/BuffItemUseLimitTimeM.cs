using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("buff_item_use_limit_time_m")]
public partial class BuffItemUseLimitTimeM
{
    [Key]
    [Column("buff_item_use_limit_time_id")]
    public int BuffItemUseLimitTimeId { get; set; }

    [Required]
    [Column("start_time")]
    public string StartTime { get; set; }

    [Required]
    [Column("end_time")]
    public string EndTime { get; set; }
}
