using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Live;

[PrimaryKey("RotationGroupId", "BaseDate")]
[Table("special_live_rotation_m")]
public partial class SpecialLiveRotationM
{
    [Key]
    [Column("rotation_group_id")]
    public int RotationGroupId { get; set; }

    [Column("live_difficulty_id")]
    public int LiveDifficultyId { get; set; }

    [Key]
    [Column("base_date")]
    public string BaseDate { get; set; }
}
