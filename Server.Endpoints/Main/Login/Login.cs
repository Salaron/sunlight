using Server.Common;

namespace Server.Endpoints.Main.Login;

internal record LoginRequest(string LoginKey, string LoginPasswd);

internal record LoginResponse(int UserId, string AuthorizeToken, bool IdfaEnabled, bool SkipLoginNews);

[Endpoint("login/login", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true)]
internal class Login : Action<LoginRequest, LoginResponse>
{
    public override Task<LoginResponse> ExecuteAsync(LoginRequest requestBody)
    {
        return Task.FromResult(new LoginResponse(0, "", false, false));
    }
}