using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitId", "MemberTagId")]
[Table("unit_member_tag_m")]
public partial class UnitMemberTagM
{
    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }

    [Key]
    [Column("member_tag_id")]
    public int MemberTagId { get; set; }
}
