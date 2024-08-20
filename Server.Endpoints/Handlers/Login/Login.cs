using Microsoft.EntityFrameworkCore;
using Server.Common;
using Server.Common.Login;
using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record LoginRequest(string LoginKey, string LoginPasswd);

internal record LoginResponse(int UserId, string AuthorizeToken, bool IdfaEnabled, bool SkipLoginNews);

[Endpoint("login/login", ignoreVersion: true, requireAuthorization: false)]
internal class LoginEndpoint(
    ICredentialsHelper credentialsHelper,
    IActionContext actionContext,
    ServerContext serverContext,
    IAuthKeyRepository authKeyRepository) : Action<LoginRequest, LoginResponse>
{
    public override async Task<LoginResponse> ExecuteAsync(LoginRequest requestBody)
    {
        var authKey = authKeyRepository.Get(actionContext.AuthorizeHeader.Token);
        if (authKey == null)
            throw new ActionException(500);

        var (login, passwd) =
            credentialsHelper.DecryptCredentials(authKey, requestBody.LoginKey, requestBody.LoginPasswd);

        var user = await serverContext.Users.FirstOrDefaultAsync(u => u.LoginKey == login && u.LoginPasswd == passwd);
        if (user is null)
            throw new ActionException(407);

        user.SessionKey = authKey.SessionKey;
        user.AuthorizeToken = Guid.NewGuid().ToString();
        serverContext.Users.Update(user);

        return new LoginResponse(user.UserId, user.AuthorizeToken, false, false);
    }
}