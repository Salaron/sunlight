using Server.Common;

namespace Server.Endpoints.Handlers.Item_;

[Endpoint("item/list", usedInApi: true)]
internal class ItemListEndpoint : Action<EmptyObject, IEnumerable<EmptyObject>>
{
    public override Task<IEnumerable<EmptyObject>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<EmptyObject>());
    }
}
