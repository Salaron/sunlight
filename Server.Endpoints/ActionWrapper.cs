using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Server.Common;
using Server.Common.Config;

namespace Server.Endpoints;

public record ServerResponse<TResponse>(TResponse ResponseData, int StatusCode, ReleaseInfo[] ReleaseInfo, long ServerTimestamp);

public record ErrorResponse(int ErrorCode, string Message);

internal class ActionWrapper<TRequest, TResponse>(
    IAction<TRequest, TResponse> action,
    IOptionsSnapshot<ServerConfig> config,
    IHttpContextAccessor accessor,
    IActionContext actionContext)
{
    // TODO: exception handling, error response, release keys...
    public async Task<IResult> Execute(TRequest request)
    {
        var responseHeaders = accessor.HttpContext!.Response.Headers;
        // time to flex
        responseHeaders["X-Powered-By"] = "SunLight Project v4 (re:Light)";
        responseHeaders["Server-Version"] = config.Value.ServerVersion;

        try
        {
            var result = await action.ExecuteAsync(request);
            responseHeaders["status_code"] = "200";
            responseHeaders["authorize"] = actionContext.AuthorizeHeader.ToString();

            return TypedResults.Json(new ServerResponse<TResponse>(result, 200, config.Value.ReleaseInfo, DateTimeUtils.CurrentUnixTimeStamp()));
        }
        catch (ActionException ex)
        {
            responseHeaders["status_code"] = ex.StatusCode.ToString();
            var errorResponse = new ErrorResponse(ex.ErrorCode, ex.Message ?? string.Empty);
            return TypedResults.Json(
                new ServerResponse<ErrorResponse>(errorResponse, ex.StatusCode, config.Value.ReleaseInfo, DateTimeUtils.CurrentUnixTimeStamp()));
        }
    }
}