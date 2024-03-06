using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_attribute_m")]
public partial class UnitAttributeM
{
    [Key]
    [Column("attribute_id")]
    public int AttributeId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }
}
