using Microsoft.AspNetCore.Http;
using Server.Common.Login;
using Server.Database.Server;

namespace Server.Endpoints.Filters;

internal class AuthorizationFilter(ServerContext serverContext, IActionContext actionContext, IAuthKeyRepository authKeyRepository) : IEndpointFilter
{
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var metadata = context.HttpContext.GetEndpoint()!.Metadata.GetRequiredMetadata<EndpointMetadata>();
        
        var user = serverContext.Users.FirstOrDefault(u => u.AuthorizeToken == actionContext.AuthorizeHeader.Token);
        if (user != null)
        {
            (actionContext as ActionContext)!.UserId = user.UserId;
            (actionContext as ActionContext)!.SessionKey = Convert.FromBase64String(user.SessionKey);
            context.HttpContext.Response.Headers["user_id"] = user.UserId.ToString();
            
            user.LastActivityDate = DateTime.UtcNow;
            serverContext.Users.Update(user);
        }
        else
        {
            var authKey = authKeyRepository.Get(actionContext.AuthorizeHeader.Token);
            if (authKey != null)
                (actionContext as ActionContext)!.SessionKey = Convert.FromBase64String(authKey.SessionKey);
        }
        
        if (metadata.RequireAuthorization && user == null)
            return new ValueTask<object?>(new { Message = "Forbidden" });
        
        return next(context);
    }
}