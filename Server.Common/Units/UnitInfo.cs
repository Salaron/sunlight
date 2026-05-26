namespace Server.Common.Units;

public record UnitInfo
{
    public int UnitId { get; init; }
    public int Exp { get; init; }
    public int NextExp { get; init; }
    public int Level { get; init; }
    public int MaxLevel { get; init; }
    public int LevelLimitId { get; init; }
    public int Rank { get; init; }
    public int MaxRank { get; init; }
    public int Love { get; init; }
    public int MaxLove { get; init; }
    public int UnitSkillExp { get; init; }
    public int UnitSkillLevel { get; init; }
    public int MaxUnitSkillLevel { get; set; }
    public int MaxHp { get; init; }
    public int UnitRemovableSkillCapacity { get; init; }
    public int MaxUnitRemovableSkillCapacity { get; init; }
    public int FavoriteFlag { get; init; }
    public int DisplayRank { get; init; }
    public bool IsRankMax => Rank >= MaxRank;
    public bool IsLoveMax => Love >= MaxLove;
    public bool IsLevelMax => Level >= MaxLevel;
    public bool IsSkillLevelMax => UnitSkillLevel >= MaxUnitSkillLevel;
    public bool IsRemovableSkillCapacityMax => UnitRemovableSkillCapacity >= MaxUnitRemovableSkillCapacity;
    public bool IsSigned { get; init; }
}