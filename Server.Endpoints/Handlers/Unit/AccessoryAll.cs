using Server.Common;

namespace Server.Endpoints.Handlers.Unit;

internal record AccessoryAllResponse(List<object> AccessoryList, List<object> WearingInfo, bool EspecialCreateFlag);

[Endpoint("unit/accessoryAll", usedInApi: true)]
internal class UnitAccessoryAllEndpoint : Action<EmptyObject, AccessoryAllResponse>
{
    public override Task<AccessoryAllResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new AccessoryAllResponse([], [], false));
    }
}
