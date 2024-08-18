using Server.Common;

namespace Server.Endpoints.Main.LiveSe;

internal record LiveSeInfoResponse(List<int> LiveSeList);

[Endpoint("livese/liveseInfo", usedInApi: true)]
internal class LiveSeEndpoint : Action<EmptyObject, LiveSeInfoResponse>
{
    public override Task<LiveSeInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new LiveSeInfoResponse([]));
    }
}