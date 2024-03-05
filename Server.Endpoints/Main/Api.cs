using Microsoft.AspNetCore.Mvc;
using Server.Common;

namespace Server.Endpoints.Main;

internal record ApiRequest(string Module, string Action);

internal record ApiResponse(object Result, int Status, long TimeStamp, bool CommandNum = false);

[Endpoint("api")]
internal class Api : Action<IEnumerable<ApiRequest>, IEnumerable<ApiResponse>>
{
    public override async Task<IEnumerable<ApiResponse>> ExecuteAsync([FromBody] IEnumerable<ApiRequest> requestModules)
    {
        var result = new List<ApiResponse>();

        foreach (var requestModule in requestModules)
        {
            var hasEndpoint = EndpointsMap.EndpointToActionMap.TryGetValue(
                $"{requestModule.Module}/{requestModule.Action}",
                out var action);
            if (!hasEndpoint)
            {
                result.Add(new ApiResponse(new EmptyObject(), 600, 0));
                continue;
            }
            
            var actionResult = await action!.ExecuteAsync(requestModule);
            result.Add(new ApiResponse(actionResult, 200, 400));
        }

        return result;
    }
}