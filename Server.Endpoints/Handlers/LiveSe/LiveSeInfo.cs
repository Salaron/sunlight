using Microsoft.EntityFrameworkCore;
using Server.Common;
using Server.Database.Game;

namespace Server.Endpoints.Main.LiveSe;

internal record LiveSeInfoResponse(List<int> LiveSeList);

[Endpoint("livese/liveseInfo", usedInApi: true)]
internal class LiveSeEndpoint(ItemContext itemContext) : Action<EmptyObject, LiveSeInfoResponse>
{
    public override async Task<LiveSeInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var liveSeList = await itemContext.LiveSeM.Select(se => se.LiveSeId).ToListAsync();
        return new LiveSeInfoResponse(liveSeList);
    }
}