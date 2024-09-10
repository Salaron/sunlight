using Server.Common;
using Server.Common.Tutorial;
using Server.Database.Server;

namespace Server.Endpoints.Handlers.Tutorial;

[Endpoint("tutorial/skip")]
internal class TutorialSkipEndpoint(IActionContext context, ITutorialService tutorialService)
    : Action<EmptyObject, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(EmptyObject requestBody)
    {
        await tutorialService.SkipAsync(context.UserId);

        return new EmptyObject();
    }
}
