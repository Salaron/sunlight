using Server.Common;

namespace Server.Endpoints.Handlers.Scenario;

internal record ScenarioStatusResponse(List<object> ScenarioStatusList);

[Endpoint("scenario/scenarioStatus", usedInApi: true)]
internal class StatusEndpoint : Action<EmptyObject, ScenarioStatusResponse>
{
    public override Task<ScenarioStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new ScenarioStatusResponse([]));
    }
}
