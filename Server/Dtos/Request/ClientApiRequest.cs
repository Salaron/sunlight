using System.Text.Json.Serialization;

namespace SunLight.Dtos.Request;

[Serializable]
public class ClientApiRequest
{
    public string Module { get; init; }
    public string Action { get; init; }

    [JsonPropertyName("timeStamp")]
    public long TimeStamp { get; init; }
}