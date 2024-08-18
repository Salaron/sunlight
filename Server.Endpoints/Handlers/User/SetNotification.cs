using Server.Common;

namespace Server.Endpoints.Main.Login;

[Endpoint("user/setNotification")]
internal class SetNotificationEndpoint : Action<EmptyObject, IEnumerable<EmptyObject>>
{
    public override Task<IEnumerable<EmptyObject>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<EmptyObject>());
    }
}