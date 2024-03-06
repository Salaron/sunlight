using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Item;

[Table("background_shader_param_m")]
public partial class BackgroundShaderParamM
{
    [Key]
    [Column("background_shader_param_id")]
    public int BackgroundShaderParamId { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    [Required]
    [Column("params")]
    public string Params { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
