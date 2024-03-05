using Microsoft.AspNetCore.Http;

namespace Server.Endpoints.Filters;

internal class ClientVersionFilter : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var metadata = context.HttpContext.GetEndpoint()!.Metadata.GetRequiredMetadata<EndpointMetadata>();

        if (/* metadata.IgnoreVersion */ true)
        {
            context.HttpContext.Response.Headers["version_up"] = "0";
        }
        
        return next(context);
    }
}