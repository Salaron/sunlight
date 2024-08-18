using Microsoft.EntityFrameworkCore;
using Server.Common;
using Server.Common.Login;
using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record LoginRequest(string LoginKey, string LoginPasswd);

internal record LoginResponse(int UserId, string AuthorizeToken, bool IdfaEnabled, bool SkipLoginNews);

[Endpoint("login/login", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true, requireAuthorization: false)]
internal class LoginEndpoint(ICredentialsHelper credentialsHelper, IActionContext actionContext, ServerContext serverContext) : Action<LoginRequest, LoginResponse>
{
    public override async Task<LoginResponse> ExecuteAsync(LoginRequest requestBody)
    {
        var (login, passwd) = credentialsHelper.DecryptCredentials(actionContext.AuthorizeHeader.Token, requestBody.LoginKey, requestBody.LoginPasswd);

        var user = await serverContext.Users.FirstOrDefaultAsync(u => u.LoginKey == login && u.LoginPasswd == passwd);
        if (user is null)
            throw new ActionException(407);

        user.AuthorizeToken = Guid.NewGuid().ToString();
        user.LastLogin = DateTime.UtcNow;
        serverContext.Users.Update(user);
        await serverContext.SaveChangesAsync();
        
        return new LoginResponse(user.UserId, user.AuthorizeToken, false, false);
    }
}