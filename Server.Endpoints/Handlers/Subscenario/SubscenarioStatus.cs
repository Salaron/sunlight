using Server.Common;

namespace Server.Endpoints.Main.Subscenario;

internal record SubscenarioStatusResponse(List<object> SubscenarioStatusList, List<int> UnlockedSubscenarioIds);

[Endpoint("subscenario/subscenarioStatus", usedInApi: true)]
internal class StatusEndpoint : Action<EmptyObject, SubscenarioStatusResponse>
{
    public override Task<SubscenarioStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new SubscenarioStatusResponse([], []));
    }
}