using SunLight.Models;

namespace SunLight.Dtos.Response;

[Serializable]
public class ServerResponse<T> where T : BaseResponse
{
    public T ResponseData { get; set; }
    public int StatusCode { get; set; } = 200;
    public List<ReleaseInfo> ReleaseInfo { get; } = new();

    public ServerResponse(T responseData)
    {
        ResponseData = responseData;
    }

    public ServerResponse(T responseData, int statusCode = 200) : this(responseData)
    {
        StatusCode = statusCode;
    }
}