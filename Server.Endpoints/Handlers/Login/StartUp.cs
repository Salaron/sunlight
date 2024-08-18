using Server.Common;
using Server.Common.Login;
using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record StartUpRequest(string LoginKey, string LoginPasswd);

internal record StartUpResponse(int UserId, string AuthorizeToken);

[Endpoint("login/startUp", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true, requireAuthorization: false)]
internal class StartUpEndpoint(ICredentialsHelper credentialsHelper, IActionContext actionContext, ServerContext serverContext) : Action<StartUpRequest, StartUpResponse>
{
    public override async Task<StartUpResponse> ExecuteAsync(StartUpRequest requestBody)
    {
        var (login, passwd) = credentialsHelper.DecryptCredentials(actionContext.AuthorizeHeader.Token, requestBody.LoginKey, requestBody.LoginPasswd);

        var user = new User
        {
            LoginKey = login,
            LoginPasswd = passwd,
            AuthorizeToken = Guid.NewGuid().ToString()
        };
        serverContext.Users.Add(user);
        await serverContext.SaveChangesAsync();
        
        return new StartUpResponse(user.UserId, user.AuthorizeToken);
    }
}