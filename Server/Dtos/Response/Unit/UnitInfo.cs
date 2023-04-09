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
    public int IsRankMax { get; set; }
    public int IsLoveMax { get; set; }
    public int IsLevelMax { get; set; }
    public int IsSigned { get; set; }
    public int IsSkillLevelMax { get; set; }
    public int IsRemovableSkillCapacityMax { get; set; }
    public DateTime InsertDate { get; set; }
}