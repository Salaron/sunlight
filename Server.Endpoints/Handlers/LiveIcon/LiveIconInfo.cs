using Server.Common;

namespace Server.Endpoints.Main.LiveIcon;

internal record LiveIconInfoResponse(List<int> LiveNotesIconList);

[Endpoint("liveicon/liveiconInfo", usedInApi: true)]
internal class LiveIconInfoEndpoint : Action<EmptyObject, LiveIconInfoResponse>
{
    public override Task<LiveIconInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new LiveIconInfoResponse([]));
    }
}