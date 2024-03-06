using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[Table("training_mode_m")]
public partial class TrainingModeM
{
    [Key]
    [Column("training_mode_id")]
    public int TrainingModeId { get; set; }

    [Column("recovery_cost")]
    public int RecoveryCost { get; set; }

    [Required]
    [Column("start_date")]
    public string StartDate { get; set; }
}
