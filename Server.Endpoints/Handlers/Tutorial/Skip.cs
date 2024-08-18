using Server.Common;
using Server.Database.Server;

namespace Server.Endpoints.Main.Tutorial;

[Endpoint("tutorial/skip")]
internal class TutorialSkipEndpoint(ServerContext serverContext, IActionContext context) : Action<EmptyObject, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(EmptyObject requestBody)
    {
        var user = await serverContext.Users.FindAsync(context.UserId);
        user.TutorialState = -1;
        serverContext.Users.Update(user);
        await serverContext.SaveChangesAsync();

        return new EmptyObject();
    }
}