using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Database.Game.Unit;

[Table("unit_m")]
public partial class UnitM
{
    [Key]
    [Column("unit_id")]
    public int UnitId { get; set; }

    [Column("unit_number")]
    public int UnitNumber { get; set; }

    [Column("unit_type_id")]
    public int UnitTypeId { get; set; }

    [Column("album_series_id")]
    public int? AlbumSeriesId { get; set; }

    [Column("eponym")]
    public string Eponym { get; set; }

    [Column("eponym_en")]
    public string EponymEn { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Column("name_en")]
    public string NameEn { get; set; }

    [Column("normal_card_id")]
    public int NormalCardId { get; set; }

    [Column("rank_max_card_id")]
    public int RankMaxCardId { get; set; }

    [Required]
    [Column("normal_icon_asset")]
    public string NormalIconAsset { get; set; }

    [Column("normal_icon_asset_en")]
    public string NormalIconAssetEn { get; set; }

    [Required]
    [Column("rank_max_icon_asset")]
    public string RankMaxIconAsset { get; set; }

    [Column("rank_max_icon_asset_en")]
    public string RankMaxIconAssetEn { get; set; }

    [Column("normal_unit_navi_asset_id")]
    public int NormalUnitNaviAssetId { get; set; }

    [Column("rank_max_unit_navi_asset_id")]
    public int RankMaxUnitNaviAssetId { get; set; }

    [Column("rarity")]
    public int Rarity { get; set; }

    [Column("attribute_id")]
    public int AttributeId { get; set; }

    [Column("default_unit_skill_id")]
    public int? DefaultUnitSkillId { get; set; }
        
    [ForeignKey(nameof(DefaultUnitSkillId))]
    public virtual UnitSkillM UnitSkill { get; set; }

    [Column("skill_asset_voice_id")]
    public int? SkillAssetVoiceId { get; set; }

    [Column("default_leader_skill_id")]
    public int? DefaultLeaderSkillId { get; set; }

    [Column("default_removable_skill_capacity")]
    public int DefaultRemovableSkillCapacity { get; set; }

    [Column("max_removable_skill_capacity")]
    public int MaxRemovableSkillCapacity { get; set; }

    [Column("disable_rank_up")]
    public int DisableRankUp { get; set; }

    [Column("rank_min")]
    public int RankMin { get; set; }

    [Column("rank_max")]
    public int RankMax { get; set; }

    [Column("unit_level_up_pattern_id")]
    public int UnitLevelUpPatternId { get; set; }

    [Column("hp_max")]
    public int HpMax { get; set; }

    [Column("smile_max")]
    public int SmileMax { get; set; }

    [Column("pure_max")]
    public int PureMax { get; set; }

    [Column("cool_max")]
    public int CoolMax { get; set; }

    [Column("reinforce_item_rank_up_cost")]
    public int? ReinforceItemRankUpCost { get; set; }

    [Column("sub_unit_type_id")]
    public int? SubUnitTypeId { get; set; }

    [Column("release_tag")]
    public string ReleaseTag { get; set; }

    [Column("_encryption_release_id")]
    public int? EncryptionReleaseId { get; set; }
}
