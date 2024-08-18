using Server.Common;

namespace Server.Endpoints.Main.Login;

internal record UserNavi(int UserId, int UnitOwningUserId);

internal record UserGetNaviRequest(UserNavi User);

[Endpoint("user/getNavi", usedInApi: true)]
internal class GetNaviEndpoint : Action<EmptyObject, UserGetNaviRequest>
{
    public override Task<UserGetNaviRequest> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new UserGetNaviRequest(null));
    }
}