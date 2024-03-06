using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("multi_unit_switch_setting_m")]
public partial class MultiUnitSwitchSettingM
{
    [Key]
    [Column("multi_unit_switch_setting_id")]
    public int MultiUnitSwitchSettingId { get; set; }

    [Column("base_unit_id")]
    public int BaseUnitId { get; set; }

    [Column("to_unit_id")]
    public int ToUnitId { get; set; }

    [Column("order_num")]
    public int OrderNum { get; set; }

    [Column("scenario_char_asset_id")]
    public int ScenarioCharAssetId { get; set; }

    [Column("character_name")]
    public string CharacterName { get; set; }

    [Column("character_name_en")]
    public string CharacterNameEn { get; set; }

    [Column("asset_voice_id")]
    public int? AssetVoiceId { get; set; }

    [Column("asset_background_id")]
    public int? AssetBackgroundId { get; set; }
}
