using Server.Common;

namespace Server.Endpoints.Main.Award;

internal record AwardInfo(int AwardId, bool IsSet, DateTime InsertDate);

internal record AwardInfoResponse(List<AwardInfo> AwardInfo);

[Endpoint("award/awardInfo", usedInApi: true)]
internal class AwardInfoEndpoint : Action<EmptyObject, AwardInfoResponse>
{
    public override Task<AwardInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new AwardInfoResponse([]));
    }
}