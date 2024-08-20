using Server.Common;
using Server.Common.Login;
using Server.Common.Users;
using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record StartUpRequest(string LoginKey, string LoginPasswd);

internal record StartUpResponse(int UserId);

[Endpoint("login/startUp", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true, requireAuthorization: false)]
internal class StartUpEndpoint(
    IActionContext actionContext,
    IUserService userService,
    ICredentialsHelper credentialsHelper,
    IAuthKeyRepository authKeyRepository) : Action<StartUpRequest, StartUpResponse>
{
    public override async Task<StartUpResponse> ExecuteAsync(StartUpRequest requestBody)
    {
        var authKey = authKeyRepository.Get(actionContext.AuthorizeHeader.Token);
        if (authKey == null)
            throw new ActionException(499);

        var (login, passwd) =
            credentialsHelper.DecryptCredentials(authKey, requestBody.LoginKey, requestBody.LoginPasswd);

        var user = await userService.CreateAsync(login, passwd);

        return new StartUpResponse(user.UserId);
    }
}