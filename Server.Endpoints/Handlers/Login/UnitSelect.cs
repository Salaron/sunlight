using Server.Common.Items;
using Server.Common.Live;
using Server.Database.Server;

namespace Server.Endpoints.Handlers.Login;

internal record UnitSelectRequest(int UnitInitialSetId);

internal record UnitSelectResponse(List<int> UnitId);

[Endpoint("login/unitSelect")]
internal class UnitSelectEndpoint(
    ItemManager itemManager,
    IActionContext context,
    IUnitDeckService deckService,
    ServerContext serverContext)
    : Action<UnitSelectRequest, UnitSelectResponse>
{
    private readonly int[] _museCenters = [338, 746, 728, 415, 272, 456, 735, 763, 514];
    private readonly int[] _aqoursCenters = [1287, 1399, 1425, 1104, 1298, 1169, 1526, 1203, 1265];

    private readonly int[] _defaultUnitSet = [1391, 1529, 1527, 1487, 0, 1486, 1488, 1528, 1390];

    public override async Task<UnitSelectResponse> ExecuteAsync(UnitSelectRequest requestBody)
    {
        var units = _defaultUnitSet;
        units[4] = requestBody.UnitInitialSetId;

        var user = serverContext.Users.Find(context.UserId);

        var deckSlots = new List<UserUnitDeckSlot>();
        foreach (var (unitId, i) in units.Select((u, i) => (u, i)))
        {
            var unitOwning = await itemManager.AddAsync<UnitItem, UnitOwning>(context.UserId, Item.Unit(unitId));

            deckSlots.Add(new UserUnitDeckSlot
            {
                Position = i + 1,
                UnitOwningUser = unitOwning
            });

            if (i == 4)
            {
                user.PartnerUnit = unitOwning;
                serverContext.Users.Update(user);
            }
        }

        var initialDeckList = new List<UserUnitDeck>
        {
            new()
            {
                DeckName = "Team A",
                UnitDeckId = 1,
                MainFlag = true,
                UserId = context.UserId,
                UnitDeckSlots = deckSlots
            }
        };

        await deckService.SetDeckListAsync(context.UserId, initialDeckList);

        return new UnitSelectResponse(deckSlots.Select(slot => slot.UnitOwningUserId).ToList());
    }
}
