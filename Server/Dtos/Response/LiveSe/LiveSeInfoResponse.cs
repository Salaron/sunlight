namespace SunLight.Dtos.Response.LiveSe;

[Serializable]
public class LiveSeInfoResponse
{
    public IEnumerable<int> LiveSeList { get; set; }
}