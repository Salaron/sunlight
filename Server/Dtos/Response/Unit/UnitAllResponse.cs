namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitAllResponse
{
    public IEnumerable<UnitInfo> Active { get; set; }
    public IEnumerable<UnitInfo> Waiting { get; set; }
}