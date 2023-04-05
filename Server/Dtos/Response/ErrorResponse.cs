namespace SunLight.Dtos.Response;

[Serializable]
public class ErrorResponse
{
    public int ErrorCode { get; }

    public ErrorResponse(int errorCode)
    {
        ErrorCode = errorCode;
    }
}