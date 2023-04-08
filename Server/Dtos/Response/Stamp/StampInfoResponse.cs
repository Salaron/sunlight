namespace SunLight.Dtos.Response.Stamp;

[Serializable]
public class StampInfoResponse
{
    public IEnumerable<int> OwningStampIds { get; set; }
    public IEnumerable<object> StampSetting { get; set; }
}