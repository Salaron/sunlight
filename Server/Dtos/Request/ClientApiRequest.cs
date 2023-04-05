namespace SunLight.Dtos.Request;

[Serializable]
public class ClientApiRequest
{
    public string Module { get; init; }
    public string Action { get; init; }
    public long TimeStamp { get; init; }
}