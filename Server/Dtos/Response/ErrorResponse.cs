namespace SunLight.Dtos.Response;

[Serializable]
public class ErrorResponse
{
    public int ErrorCode { get; }
    public string Message { get; }

    public ErrorResponse(int errorCode, string message = "")
    {
        ErrorCode = errorCode;
        Message = message;
    }
}