using Server.Common;

namespace Server.Endpoints.Main.EventScenario;

internal record EventScenarioStatusResponse(List<object> EventScenarioList);

[Endpoint("eventscenario/status", usedInApi: true)]
internal class StatusEndpoint : Action<EmptyObject, EventScenarioStatusResponse>
{
    public override Task<EventScenarioStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new EventScenarioStatusResponse([]));
    }
}