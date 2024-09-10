using Server.Common;
using Server.Common.Unit;
using Server.Database.Server;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Unit;

internal record UnitAllResponse(IEnumerable<UnitInfoDto> Active, IEnumerable<UnitInfoDto> Waiting);

[Endpoint("unit/unitAll", usedInApi: true)]
internal class UnitAllEndpoint(IActionContext context, IUnitService unitService) : Action<EmptyObject, UnitAllResponse>
{
    public override async Task<UnitAllResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var mapper = new UnitMapper();
        var units = await unitService.GetUnitsAsync(context.UserId);
        var unitInfo = units.Select(mapper.UnitOwningToDto);

        return new UnitAllResponse(unitInfo, []);
    }
}
