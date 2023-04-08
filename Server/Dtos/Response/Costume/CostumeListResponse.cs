namespace SunLight.Dtos.Response.Costume;

[Serializable]
public class CostumeListResponse
{
    public IEnumerable<CostumeDto> CostumeList { get; set; }
}