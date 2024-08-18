using Server.Common;

namespace Server.Endpoints.Main.Unit;

internal record UnitDeckSlot(int UnitOwningUserId, int Position);

internal record UnitDeckInfoResponse(
    int UnitDeckId,
    bool MainFlag,
    string DeckName,
    List<UnitDeckSlot> UnitOwningUserIds);

[Endpoint("unit/deckInfo", usedInApi: true)]
internal class DeckInfoEndpoint : Action<EmptyObject, IEnumerable<UnitDeckInfoResponse>>
{
    public override Task<IEnumerable<UnitDeckInfoResponse>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<UnitDeckInfoResponse>());
    }
}