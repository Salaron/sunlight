using Server.Common;
using Server.Common.Users;

namespace Server.Endpoints.Main.Award;

internal record AwardSetRequest(int AwardId);

[Endpoint("award/set")]
internal class AwardSetEndpoint(IActionContext context, IUserService userService) : Action<AwardSetRequest, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(AwardSetRequest requestBody)
    {
        await userService.SetAwardAsync(context.UserId, requestBody.AwardId);

        return new EmptyObject();
    }
}