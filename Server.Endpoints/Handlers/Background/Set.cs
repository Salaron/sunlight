using Server.Common;
using Server.Common.Users;

namespace Server.Endpoints.Handlers.Background;

internal record BackgroundSetRequest(int BackgroundId);

[Endpoint("background/set")]
internal class AwardSetEndpoint(IActionContext context, IUserService userService) : Action<BackgroundSetRequest, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(BackgroundSetRequest requestBody)
    {
        await userService.SetBackgroundAsync(context.UserId, requestBody.BackgroundId);

        return new EmptyObject();
    }
}
