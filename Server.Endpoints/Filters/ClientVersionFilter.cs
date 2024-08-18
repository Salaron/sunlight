using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Server.Common.Config;

namespace Server.Endpoints.Filters;

internal class ClientVersionFilter(IOptionsSnapshot<ServerConfig> config) : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var clientVersion = context.HttpContext.Request.Headers["bundle-version"].ToString();
        
        var metadata = context.HttpContext.GetEndpoint()!.Metadata.GetRequiredMetadata<EndpointMetadata>();
        if (!metadata.IgnoreVersion && config.Value.ClientVersion != clientVersion)
        {
            context.HttpContext.Response.Headers["client-update"] = "1";
            return new ValueTask<object?>(ResponseFactory.Empty);
        }
        
        return next(context);
    }
}