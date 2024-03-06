using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("sub_unit_type_m")]
public partial class SubUnitTypeM
{
    [Key]
    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Required]
    [Column("age")]
    public string Age { get; set; }

    [Column("age_en")]
    public string AgeEn { get; set; }

    [Column("school")]
    public string School { get; set; }

    [Column("school_en")]
    public string SchoolEn { get; set; }

    [Column("hobby")]
    public string Hobby { get; set; }

    [Column("hobby_en")]
    public string HobbyEn { get; set; }

    [Column("height")]
    public string Height { get; set; }

    [Column("height_en")]
    public string HeightEn { get; set; }

    [Column("three_size")]
    public string ThreeSize { get; set; }

    [Column("three_size_en")]
    public string ThreeSizeEn { get; set; }
}
