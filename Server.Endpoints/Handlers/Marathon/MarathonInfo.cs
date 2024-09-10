using Server.Common;

namespace Server.Endpoints.Handlers.Marathon;

[Endpoint("marathon/marathonInfo", usedInApi: true)]
internal class MarathonInfoEndpoint : Action<EmptyObject, IEnumerable<EmptyObject>>
{
    public override Task<IEnumerable<EmptyObject>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<EmptyObject>());
    }
}
