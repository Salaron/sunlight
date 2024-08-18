using Server.Common;
using Server.Database.Server;

namespace Server.Endpoints.Main.Login;

internal record UserNavi(int UserId, int UnitOwningUserId);

internal record UserGetNaviResponse(UserNavi User);

[Endpoint("user/getNavi", usedInApi: true)]
internal class GetNaviEndpoint(IActionContext context, ServerContext serverContext)
    : Action<EmptyObject, UserGetNaviResponse>
{
    public override Task<UserGetNaviResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var user = serverContext.Users.Find(context.UserId);

        return Task.FromResult(new UserGetNaviResponse(new UserNavi(context.UserId, user.PartnerUnitId ?? 0)));
    }
}