using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

[PrimaryKey(nameof(UnitOwningUserId))]
public class UnitOwning
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UnitOwningUserId { get; set; }

    public uint UserId { get; set; }
    public int UnitId { get; set; }
    public int Exp { get; set; }
    public int NextExp { get; set; }
    public int Level { get; set; }
    public int MaxLevel { get; set; }
    public int LevelLimitId { get; set; }
    public int Rank { get; set; }
    public int MaxRank { get; set; }
    public int Love { get; set; }
    public int MaxLove { get; set; }
    public int UnitSkillExp { get; set; }
    public int UnitSkillLevel { get; set; }
    public int MaxUnitSkillLevel { get; set; }
    public int MaxHp { get; set; }
    public int UnitRemovableSkillCapacity { get; set; }
    public int MaxUnitRemovableSkillCapacity { get; set; }
    public int FavoriteFlag { get; set; }
    public int DisplayRank { get; set; }
    public int IsSigned { get; set; }

    public int Attribute { get; set; }
    public int StatSmile { get; set; }
    public int StatPure { get; set; }
    public int StatCool { get; set; }

    public int IsRankMax => Rank >= MaxRank ? 1 : 0;
    public int IsLoveMax => Love >= MaxLove ? 1 : 0;
    public int IsLevelMax => Level >= MaxLevel ? 1 : 0;
    public int IsSkillLevelMax => UnitSkillLevel >= MaxUnitSkillLevel ? 1 : 0;
    public int IsRemovableSkillCapacityMax => UnitRemovableSkillCapacity >= MaxUnitRemovableSkillCapacity ? 1 : 0;
    
    public DateTime InsertDate { get; set; }

    public virtual User User { get; set; }
}