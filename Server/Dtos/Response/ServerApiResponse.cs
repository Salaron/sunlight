using System.Text.Json.Serialization;

namespace SunLight.Dtos.Response;

[Serializable]
public class ApiResponse
{
    public object Result { get; set; }
    public int Status { get; set; }

    [JsonPropertyName("commandNum")]
    public bool CommandNum { get; set; }

    [JsonPropertyName("timeStamp")]
    public long TimeStamp { get; set; }

    public ApiResponse(object result, int status = 200)
    {
        Result = result;
        Status = status;
        CommandNum = false;
        TimeStamp = DateTimeUtils.CurrentUnixTimeStamp();
    }
}