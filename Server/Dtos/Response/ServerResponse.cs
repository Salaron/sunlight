namespace SunLight.Dtos.Response;

[Serializable]
public class ServerResponse<T>
{
    public T ResponseData { get; set; }
    public int StatusCode { get; set; }
    public List<ReleaseInfo> ReleaseInfo { get; } = new();

    public ServerResponse(T responseData, int statusCode)
    {
        ResponseData = responseData;
        StatusCode = statusCode;
    }
}