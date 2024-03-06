using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[PrimaryKey("UnitTypeId", "MemberTagId")]
[Table("unit_type_member_tag_m")]
public partial class UnitTypeMemberTagM
{
    [Key]
    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Key]
    [Column("member_tag_id")]
    public int MemberTagId { get; set; }
}
