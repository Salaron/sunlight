using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_navi_asset_position_m")]
public partial class UnitNaviAssetPositionM
{
    [Key]
    [Column("unit_navi_asset_id")]
    public int UnitNaviAssetId { get; set; }

    [Column("move_x")]
    public int MoveX { get; set; }

    [Column("move_y")]
    public int MoveY { get; set; }

    [Column("scale")]
    public double? Scale { get; set; }
}
