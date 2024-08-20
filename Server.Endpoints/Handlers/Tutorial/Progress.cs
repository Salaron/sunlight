using Server.Common;
using Server.Common.Tutorial;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Endpoints.Main.Tutorial;

internal record TutorialProgressRequest(TutorialState TutorialState);

[Endpoint("tutorial/progress")]
internal class TutorialProgressEndpoint(IActionContext context, ITutorialService tutorialService)
    : Action<TutorialProgressRequest, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(TutorialProgressRequest requestBody)
    {
        await tutorialService.ProcessStateAsync(context.UserId, requestBody.TutorialState);

        return new EmptyObject();
    }
}