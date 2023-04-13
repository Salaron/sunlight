using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

[PrimaryKey(nameof(UnitOwningUserId))]
public class UnitOwning
{
    public int UnitOwningUserId { get; set; }

    public int UserId { get; set; }
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

    public bool IsRankMax => Rank >= MaxRank;
    public bool IsLoveMax => Love >= MaxLove;
    public bool IsLevelMax => Level >= MaxLevel;
    public bool IsSkillLevelMax => UnitSkillLevel >= MaxUnitSkillLevel;
    public bool IsRemovableSkillCapacityMax => UnitRemovableSkillCapacity >= MaxUnitRemovableSkillCapacity;

    public DateTime InsertDate { get; set; }

    public virtual User User { get; set; }
}