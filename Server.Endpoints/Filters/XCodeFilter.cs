using Microsoft.AspNetCore.Http;
using Server.Common;

namespace Server.Endpoints.Filters;

// used in generated code
internal class XCodeFilter(XCodeVerifier xCodeVerifier) : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var metadata = context.HttpContext.GetEndpoint()!.Metadata.GetRequiredMetadata<EndpointMetadata>();
        if (metadata.XCodeCheck != XCodeCheck.Disabled)
        {
            var requestBody = context.HttpContext.Items["RawRequestBody"] as string ?? string.Empty;
            var clientCode = context.HttpContext.Request.Headers["X-Message-Code"].FirstOrDefault();
            var isKeyMatch = xCodeVerifier.Verify(clientCode, requestBody, metadata.XCodeCheck);
            if (!isKeyMatch)
            {
                // TODO
                return new ValueTask<object?>(new { Message = "Forbidden" });
            }
        }

        return next(context);
    }


}