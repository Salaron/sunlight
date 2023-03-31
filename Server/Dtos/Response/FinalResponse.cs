namespace SunLight.Dtos;

public class FinalResponse
{
    public object? ResponseData { get; set; }
    public List<ReleaseInfo> ReleaseInfo { get; } = new();
    public int StatusCode { get; set; } = 200;

    public FinalResponse(object? responseData)
    {
        ResponseData = responseData;
    }

    public FinalResponse(object? responseData, int? statusCode) : this(responseData)
    {
        StatusCode = statusCode ?? 200;
    }
}


public class ReleaseInfo
{
    public string Id { get; set; }
    public string Key { get; set; }
}