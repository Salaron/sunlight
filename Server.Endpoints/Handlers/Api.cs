

using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Server.Common;

namespace Server.Endpoints.Main;

internal record ApiRequest(string Module, string Action);

internal record ApiResponse(object Result, int Status,[property: JsonPropertyName("timeStamp")] long TimeStamp, [property: JsonPropertyName("commandNum")]bool CommandNum = false);

[Endpoint("api")]
internal class Api(IHttpContextAccessor context, ILogger<Api> logger) : Action<IEnumerable<ApiRequest>, IEnumerable<ApiResponse>>
{
    public override async Task<IEnumerable<ApiResponse>> ExecuteAsync(IEnumerable<ApiRequest> requestModules)
    {
        var result = new List<ApiResponse>();

        foreach (var requestModule in requestModules)
        {
            try
            {
                var action = context.HttpContext!.RequestServices.GetKeyedService<IAction>($"{requestModule.Module}/{requestModule.Action}");
                if (action == null)
                {
                    logger.LogError($"Action {requestModule.Module}/{requestModule.Action} not found");
                    result.Add(new ApiResponse(new EmptyObject(), 600, DateTimeUtils.CurrentUnixTimeStamp()));
                    continue;
                }

                var actionResult = await action!.ExecuteAsync(requestModule);
                result.Add(new ApiResponse(actionResult, 200, DateTimeUtils.CurrentUnixTimeStamp()));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "API request exception");
            }
        }

        return result;
    }
}