using Server.Common;
using Server.Database.Server;

namespace Server.Endpoints.Main.Tutorial;

internal record TutorialProgressRequest(int TutorialState);

[Endpoint("tutorial/progress")]
internal class TutorialProgress(ServerContext serverContext, IActionContext context) : Action<TutorialProgressRequest, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(TutorialProgressRequest requestBody)
    {
        var user = await serverContext.Users.FindAsync(context.UserId);
        user.TutorialState = requestBody.TutorialState;
        serverContext.Users.Update(user);
        
        return new EmptyObject();
    }
}