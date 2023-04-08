namespace SunLight.Dtos.Response.Costume;

[Serializable]
public class CostumeDto
{
    public int UnitId { get; set; }
    public bool IsRankMax { get; set; }
    public bool IsSigned { get; set; }
}