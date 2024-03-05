using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Server.Common;

namespace Server.Endpoints;

internal record ServerResponse<TResponse>(TResponse ResponseData, int StatusCode, ReleaseInfo[] ReleaseInfo);

// TODO: factory for this class, DI
internal class ActionWrapper<TAction, TRequest, TResponse>(TAction action) where TAction : IAction<TRequest, TResponse>
{
    // TODO: exception handling, error response, release keys...
    public async Task<JsonHttpResult<ServerResponse<TResponse>>> Wrap([FromBody] TRequest request)
    {
        var result = await action.ExecuteAsync(request);
        
        return TypedResults.Json(new ServerResponse<TResponse>(result, 200, []));
    }
}