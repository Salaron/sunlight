using SunLight.Models;

namespace SunLight.Dtos.Response;

[Serializable]
public class ServerCollectionResponse<T> where T : BaseResponse
{
    public ICollection<T> ResponseData { get; set; }
    public int StatusCode { get; set; }
    public List<ReleaseInfo> ReleaseInfo { get; } = new();

    public ServerCollectionResponse(ICollection<T> responseData, int statusCode)
    {
        ResponseData = responseData;
        StatusCode = statusCode;
    }
}