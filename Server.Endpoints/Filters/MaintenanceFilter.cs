using Microsoft.AspNetCore.Http;

namespace Server.Endpoints.Filters;

internal class MaintenanceFilter : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (/* isMaintenace? */ false)
        {
            context.HttpContext.Response.Headers["maintenance"] = "1";
            return new ValueTask<object?>();
        }
        
        return next(context);
    }
}