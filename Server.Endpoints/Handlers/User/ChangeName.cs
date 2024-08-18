using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record ChangeNameRequest(string Name);

internal record ChangeNameResponse(string AfterName);

[Endpoint("user/changeName")]
internal class ChangeNameEndpoint(ServerContext serverContext, IActionContext context) : Action<ChangeNameRequest, ChangeNameResponse>
{
    public override async Task<ChangeNameResponse> ExecuteAsync(ChangeNameRequest requestBody)
    {
        var user = await serverContext.Users.FindAsync(context.UserId);
        user.Name = requestBody.Name;
        serverContext.Users.Update(user);
        await serverContext.SaveChangesAsync();
        
        return new ChangeNameResponse(requestBody.Name);
    }
}