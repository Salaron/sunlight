using Server.Common;

namespace Server.Endpoints.Main.Exchange;

[Endpoint("exchange/owningPoint", usedInApi: true)]
internal class OwningPointEndpoint : Action<EmptyObject, IEnumerable<EmptyObject>>
{
    public override Task<IEnumerable<EmptyObject>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<EmptyObject>());
    }
}