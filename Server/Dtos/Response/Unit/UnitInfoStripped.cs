namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitInfoStripped
{
    public int UnitId { get; set; }
    public int Love { get; set; }
    public int Level { get; set; }
    public int Smile { get; set; }
    public int Pure { get; set; }
    public int Cool { get; set; }
    public int Rank { get; set; }
    public int DisplayRank { get; set; }
    public bool IsRankMax { get; set; }
    public bool IsLoveMax { get; set; }
    public bool IsLevelMax { get; set; }
    public int UnitSkillExp { get; set; }
    public int RemovableSkillCapacity { get; set; }
    public int MaxHp { get; set; }
    public List<int> RemovableSkillIds { get; set; }
    public int Exp { get; set; }
}