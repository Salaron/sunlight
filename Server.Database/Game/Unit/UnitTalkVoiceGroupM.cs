using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitId", "UnitTalkVoiceGroupId")]
[Table("unit_talk_voice_group_m")]
public partial class UnitTalkVoiceGroupM
{
    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }

    [Key]
    [Column("unit_talk_voice_group_id")]
    public int UnitTalkVoiceGroupId { get; set; }
}
