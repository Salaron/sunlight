using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Server.Common;
using Server.Common.Config;

namespace Server.Endpoints.Filters;

internal class MaintenanceFilter(IOptionsSnapshot<ServerConfig> config) : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (config.Value.Maintenance)
        {
            context.HttpContext.Response.Headers["maintenance"] = "1";
            return new ValueTask<object?>(ResponseFactory.Empty);
        }
        
        return next(context);
    }
}