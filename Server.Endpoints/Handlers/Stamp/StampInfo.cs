using Server.Common;

namespace Server.Endpoints.Main.Stamp;

internal record StampInfoResponse(List<int> OwningStampIds, List<object> StampSetting);

[Endpoint("stamp/stampInfo", usedInApi: true)]
internal class StampInfoEndpoint : Action<EmptyObject, StampInfoResponse>
{
    public override Task<StampInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new StampInfoResponse([], []));
    }
}