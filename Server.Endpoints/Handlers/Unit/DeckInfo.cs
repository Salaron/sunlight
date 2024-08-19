using Server.Common;
using Server.Common.Live;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Main.Unit;

internal record UnitDeckSlot(int UnitOwningUserId, int Position);

internal record UnitDeckInfoResponse(
    int UnitDeckId,
    bool MainFlag,
    string DeckName,
    IEnumerable<UnitDeckSlot> UnitOwningUserIds);

[Endpoint("unit/deckInfo", usedInApi: true)]
internal class DeckInfoEndpoint(IActionContext context, IUnitDeckService deckService)
    : Action<EmptyObject, IEnumerable<UnitDeckInfoResponse>>
{
    public override async Task<IEnumerable<UnitDeckInfoResponse>> ExecuteAsync(EmptyObject requestBody)
    {
        var mapper = new UnitMapper();
        var deckList = await deckService.GetDeckListAsync(context.UserId);

        var response = deckList.Select(mapper.UnitDeckToDto);

        return response;
    }
}