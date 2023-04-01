namespace SunLight.Dtos.Request;

[Serializable]
public class ApiRequest
{
    public string Module { get; init; }
    public string Action { get; init; }
    public uint TimeStamp { get; init; }
}