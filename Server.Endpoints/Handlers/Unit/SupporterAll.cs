using Server.Common;

namespace Server.Endpoints.Main.Unit;

internal record SupportUnitDetail(int UnitId, int Amount);

internal record SupporterAllResponse(List<SupportUnitDetail> UnitSupportList);

[Endpoint("unit/supporterAll", usedInApi: true)]
internal class SupporterAllEndpoint : Action<EmptyObject, SupporterAllResponse>
{
    public override Task<SupporterAllResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new SupporterAllResponse([]));
    }
}