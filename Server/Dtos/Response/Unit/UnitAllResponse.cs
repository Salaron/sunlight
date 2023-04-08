namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitAllResponse
{
    public IEnumerable<object> Active { get; set; }
    public IEnumerable<object> Waiting { get; set; }
}