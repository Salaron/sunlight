using Microsoft.EntityFrameworkCore;
using Server.Common;
using Server.Database.Game;

namespace Server.Endpoints.Handlers.LiveIcon;

internal record LiveIconInfoResponse(List<int> LiveNotesIconList);

[Endpoint("liveicon/liveiconInfo", usedInApi: true)]
internal class LiveIconInfoEndpoint(ItemContext itemContext) : Action<EmptyObject, LiveIconInfoResponse>
{
    public override async Task<LiveIconInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var liveIconList = await itemContext.LiveSeM.Select(se => se.LiveSeId).ToListAsync();
        return new LiveIconInfoResponse(liveIconList);
    }
}
