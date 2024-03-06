using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_talk_voice_m")]
public partial class UnitTalkVoiceM
{
    [Key]
    [Column("unit_talk_voice_id")]
    public int UnitTalkVoiceId { get; set; }

    [Column("unit_talk_voice_group_id")]
    public int UnitTalkVoiceGroupId { get; set; }

    [Column("seq")]
    public int Seq { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Column("asset_voice_id")]
    public int AssetVoiceId { get; set; }
}
