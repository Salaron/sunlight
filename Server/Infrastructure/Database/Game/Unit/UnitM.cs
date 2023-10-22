using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunLight.Infrastructure.Database.Game.Unit;

public class UnitM
{
    [Key]
    public int UnitId { get; set; }
    
    public int UnitNumber { get; set; }
    public int UnitTypeId { get; set; }
    public int AlbumSeriesId { get; set; }
    public string Eponym { get; set; }
    public string EponymEn { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public int NormalCardId { get; set; }
    public int RankMaxCardId { get; set; }
    public string NormalIconAsset { get; set; }
    public string NormalIconAssetEn { get; set; }
    public string RankMaxIconAsset { get; set; }
    public string RankMaxIconAssetEn { get; set; }
    public int NormalUnitNaviAssetId { get; set; }
    public int RankMaxUnitNaviAssetId { get; set; }
    public int Rarity { get; set; }
    public int AttributeId { get; set; }

    public int? DefaultUnitSkillId { get; set; }

    [ForeignKey(nameof(DefaultUnitSkillId))]
    public virtual UnitSkillM? UnitSkill { get; set; }

    public int? SkillAssetVoiceId { get; set; }
    public int? DefaultLeaderSkillId { get; set; }
    public int DefaultRemovableSkillCapacity { get; set; }
    public int MaxRemovableSkillCapacity { get; set; }
    public int DisableRankUp { get; set; }
    public int RankMin { get; set; }
    public int RankMax { get; set; }

    public int UnitLevelUpPatternId { get; set; }

    public int HpMax { get; set; }
    public int SmileMax { get; set; }
    public int PureMax { get; set; }
    public int CoolMax { get; set; }
    public int? ReinforceItemRankUpCost { get; set; }
    public int? SubUnitTypeId { get; set; }
}