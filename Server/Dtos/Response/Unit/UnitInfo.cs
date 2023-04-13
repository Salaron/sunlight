namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitInfo
{
    public int UnitOwningUserId { get; set; }
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
    public int MaxHp { get; set; }
    public int UnitRemovableSkillCapacity { get; set; }
    public int FavoriteFlag { get; set; }
    public int DisplayRank { get; set; }
    public bool IsRankMax { get; set; }
    public bool IsLoveMax { get; set; }
    public bool IsLevelMax { get; set; }
    public bool IsSigned { get; set; }
    public bool IsSkillLevelMax { get; set; }
    public bool IsRemovableSkillCapacityMax { get; set; }
    public DateTime InsertDate { get; set; }
}