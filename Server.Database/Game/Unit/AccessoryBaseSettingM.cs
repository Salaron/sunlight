using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("accessory_base_setting_m")]
public partial class AccessoryBaseSettingM
{
    [Key]
    [Column("accessory_base_setting_id")]
    public int AccessoryBaseSettingId { get; set; }

    [Column("owning_capacity")]
    public int OwningCapacity { get; set; }

    [Column("owning_material_capacity")]
    public int OwningMaterialCapacity { get; set; }
}
