namespace SunLight.Dtos.Response;

[Serializable]
public abstract class BaseResponse
{
    public long ServerTimestamp { get; }

    protected BaseResponse()
    {
        ServerTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}