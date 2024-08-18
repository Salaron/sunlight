using Server.Common;

namespace Server.Endpoints.Main.Item;

[Endpoint("item/list", usedInApi: true)]
internal class ItemListEndpoint : Action<EmptyObject, IEnumerable<EmptyObject>>
{
    public override Task<IEnumerable<EmptyObject>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<EmptyObject>());
    }
}