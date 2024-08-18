using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Server.Common;
using Server.Common.Config;

namespace Server.Endpoints;

internal record ServerResponse<TResponse>(TResponse ResponseData, int StatusCode, ReleaseInfo[] ReleaseInfo);

internal record ErrorResponse(int ErrorCode, string Message);

internal class ActionWrapper<TRequest, TResponse>(IAction<TRequest, TResponse> action, IOptionsSnapshot<ServerConfig> config)
{
    // TODO: exception handling, error response, release keys...
    public async Task<IResult> Execute([FromBody] TRequest request)
    {
        try
        {
            var result = await action.ExecuteAsync(request);
            return TypedResults.Json(new ServerResponse<TResponse>(result, 200, config.Value.ReleaseInfo));
        }
        catch (ActionException ex)
        {
            return TypedResults.Json(new ErrorResponse(ex.ErrorCode, ex.Message!), statusCode: ex.StatusCode);
        }
    }
}