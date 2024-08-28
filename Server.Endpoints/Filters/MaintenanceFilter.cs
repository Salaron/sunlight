using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Server.Common.Config;

namespace Server.Endpoints.Filters;

internal class MaintenanceFilter(IOptionsSnapshot<ServerConfig> config) : IEndpointFilter
{
    public ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var metadata = context.HttpContext.GetEndpoint()!.Metadata.GetRequiredMetadata<EndpointMetadata>();

        var currentTime = DateTime.UtcNow;
        var isUnderMaintenance = config.Value.Maintenance.Schedule.Any(schedule => currentTime >= schedule.Start && currentTime <= schedule.End) || config.Value.Maintenance.IsForced;
        var isAllowedEndpoint = metadata.RequireAuthorization == false;

        if (isUnderMaintenance && !isAllowedEndpoint)
        {
            context.HttpContext.Response.Headers["maintenance"] = "1";
            return new ValueTask<object>(ResponseFactory.CreateEmptyResponse());
        }

        return next(context);
    }
}