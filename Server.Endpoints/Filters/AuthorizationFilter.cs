using Microsoft.AspNetCore.Http;
using Server.Database.Server;

namespace Server.Endpoints.Filters;

internal class AuthorizationFilter(ServerContext serverContext, IActionContext actionContext) : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var metadata = context.HttpContext.GetEndpoint()!.Metadata.GetRequiredMetadata<EndpointMetadata>();
        
        var user = serverContext.Users.FirstOrDefault(u => u.AuthorizeToken == actionContext.AuthorizeHeader.Token);
        if (user != null)
        {
            (actionContext as ActionContext)!.UserId = user.UserId;
            context.HttpContext.Response.Headers["user_id"] = user.UserId.ToString();
        }
        
        if (metadata.RequireAuthorization && user == null)
            return new ValueTask<object?>(new { Message = "Forbidden" });
        
        return next(context);
    }
}