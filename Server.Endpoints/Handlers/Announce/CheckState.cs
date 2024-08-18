using Server.Common;

namespace Server.Endpoints.Main.Announce;

internal record AnnounceCheckStateResponse(bool HasUnreadAnnounce);

[Endpoint("announce/checkState", usedInApi: true)]
internal class AnnounceCheckStateEndpoint : Action<EmptyObject, AnnounceCheckStateResponse>
{
    public override Task<AnnounceCheckStateResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new AnnounceCheckStateResponse(HasUnreadAnnounce: false));
    }
}