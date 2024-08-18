using Server.Common;

namespace Server.Endpoints.Main.MultiUnit;

internal record MultiUnitScenarioStatusResponse(List<object> MultiUnitScenarioStatusList);

[Endpoint("multiunit/multiunitscenarioStatus", usedInApi: true)]
internal class StatusEndpoint : Action<EmptyObject, MultiUnitScenarioStatusResponse>
{
    public override Task<MultiUnitScenarioStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new MultiUnitScenarioStatusResponse([]));
    }
}