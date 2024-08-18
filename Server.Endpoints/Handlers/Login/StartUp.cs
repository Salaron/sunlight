using Server.Common;
using Server.Common.Login;
using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record StartUpRequest(string LoginKey, string LoginPasswd);

internal record StartUpResponse(int UserId, string AuthorizeToken);

[Endpoint("login/startUp", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true, requireAuthorization: false)]
internal class StartUpEndpoint(
    ICredentialsHelper credentialsHelper,
    IActionContext actionContext,
    ServerContext serverContext,
    IAuthKeyRepository authKeyRepository) : Action<StartUpRequest, StartUpResponse>
{
    public override async Task<StartUpResponse> ExecuteAsync(StartUpRequest requestBody)
    {
        var authKey = authKeyRepository.Get(actionContext.AuthorizeHeader.Token);
        if (authKey == null)
            throw new ActionException(499);

        var (login, passwd) =
            credentialsHelper.DecryptCredentials(authKey, requestBody.LoginKey, requestBody.LoginPasswd);

        var user = new User
        {
            LoginKey = login,
            LoginPasswd = passwd,
            SessionKey = authKey.SessionKey,
            AuthorizeToken = Guid.NewGuid().ToString()
        };
        serverContext.Users.Add(user);
        await serverContext.SaveChangesAsync();

        return new StartUpResponse(user.UserId, user.AuthorizeToken);
    }
}