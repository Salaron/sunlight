using Server.Common;

namespace Server.Endpoints;

public static class ResponseFactory
{
    public static ServerResponse<EmptyObject> CreateEmptyResponse()
    {
        return new ServerResponse<EmptyObject>(new EmptyObject(), 200, [], DateTimeUtils.CurrentUnixTimeStamp());
    }

    public static ServerResponse<ErrorResponse> CreateErrorResponse(string message)
    {
        return new ServerResponse<ErrorResponse>(new ErrorResponse(600, message), 600, [],
            DateTimeUtils.CurrentUnixTimeStamp());
    }
}