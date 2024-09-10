using Server.Common;

namespace Server.Endpoints.Handlers.Handover;

internal record KidStatusResponse(bool HasKlabId);

[Endpoint("handover/kidStatus")]
internal class KidStatusEndpoint : Action<EmptyObject, KidStatusResponse>
{
    public override Task<KidStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new KidStatusResponse(true));
    }
}
