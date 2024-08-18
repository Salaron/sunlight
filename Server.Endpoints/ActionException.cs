namespace Server.Endpoints;

public class ActionException(int errorCode, string? message = null, int statusCode = 600) : Exception
{
    public int ErrorCode { get; } = errorCode;
    public int StatusCode { get; } = statusCode;
    public string? Message { get; } = message;
}