using Server.Common;

namespace Server.Endpoints.Handlers.Navigation;

internal record SpecialCutinResponse(List<object> SpecialCutinList);

[Endpoint("navigation/specialCutin", usedInApi: true)]
internal class SpecialCutinEndpoint : Action<EmptyObject, SpecialCutinResponse>
{
    public override Task<SpecialCutinResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new SpecialCutinResponse([]));
    }
}
