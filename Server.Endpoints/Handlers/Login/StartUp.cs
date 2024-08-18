using Server.Common;

namespace Server.Endpoints.Main.Login;

[Endpoint("login/startUp", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true)]
internal class StartUp : Action<LoginRequest, LoginResponse>
{
    public override Task<LoginResponse> ExecuteAsync(LoginRequest requestBody)
    {
        return Task.FromResult(new LoginResponse(1, Guid.NewGuid().ToString(), false, false));
    }
}