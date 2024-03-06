using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("hidden_unit_m")]
public partial class HiddenUnitM
{
    [Key]
    [Column("hidden_unit_id")]
    public int HiddenUnitId { get; set; }

    [Column("rarity")]
    public int Rarity { get; set; }

    [Column("member_category")]
    public int MemberCategory { get; set; }

    [Column("unit_navi_asset_id")]
    public int UnitNaviAssetId { get; set; }

    [Column("attribute_id")]
    public int AttributeId { get; set; }

    [Column("skill_asset_voice_id")]
    public int? SkillAssetVoiceId { get; set; }

    [Column("trigger_type")]
    public int TriggerType { get; set; }

    [Column("trigger_value")]
    public int TriggerValue { get; set; }

    [Column("activation_rate")]
    public int ActivationRate { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
