using Server.Common;

namespace Server.Endpoints.Main.Background;

internal record BackgroundInfo(int BackgroundId, bool IsSet, DateTime InsertDate);

internal record BackgroundInfoResponse(List<BackgroundInfo> BackgroundInfo);

[Endpoint("background/backgroundInfo", usedInApi: true)]
internal class AwardInfoEndpoint : Action<EmptyObject, BackgroundInfoResponse>
{
    public override Task<BackgroundInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new BackgroundInfoResponse([]));
    }
}