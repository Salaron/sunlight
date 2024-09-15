using Microsoft.EntityFrameworkCore;
using Server.Common.Live;
using Server.Database.Server;

namespace Server.Common.Units;

internal class UnitDeckService(ServerContext serverContext) : IUnitDeckService
{
    public async Task SetDeckListAsync(int userId, List<UserUnitDeck> deckList)
    {
        // TODO: validation
        var userDecks = serverContext.UserUnitDeck.Where(u => u.UserId == userId);
        serverContext.UserUnitDeck.RemoveRange(userDecks);

        await serverContext.UserUnitDeck.AddRangeAsync(deckList);
    }

    public async Task<List<UserUnitDeck>> GetDeckListAsync(int userId)
    {
        var deckList = await serverContext.UserUnitDeck
            .Include(deck => deck.UnitDeckSlots)
            .Where(deck => deck.UserId == userId)
            .ToListAsync();

        return deckList;
    }

    public async Task<LiveShowDeckInfo> GetDeckForLiveShowAsync(int userId, int unitDeckId)
    {
        var deck = await serverContext.UserUnitDeck
            .Include(deck => deck.UnitDeckSlots)
            .ThenInclude(slot => slot.UnitOwningUser)
            .Where(deck => deck.UserId == userId && deck.UnitDeckId == unitDeckId)
            .FirstAsync();

        // TODO: accessories, school idol skills, etc...

        var units = new List<UnitStats>();
        var totalSmile = 0;
        var totalPure = 0;
        var totalCool = 0;
        var totalHp = 0;
        foreach (var slot in deck.UnitDeckSlots)
        {
            totalSmile += slot.UnitOwningUser.StatSmile;
            totalPure += slot.UnitOwningUser.StatPure;
            totalCool += slot.UnitOwningUser.StatCool;
            totalHp += slot.UnitOwningUser.MaxHp;
            units.Add(new UnitStats
            {
                Smile = slot.UnitOwningUser.StatSmile,
                Pure = slot.UnitOwningUser.StatPure,
                Cool = slot.UnitOwningUser.StatCool
            });
        }

        var deckInfo = new LiveShowDeckInfo
        {
            UnitDeckId = deck.UnitDeckId,
            TotalSmile = totalSmile,
            TotalPure = totalPure,
            TotalCool = totalCool,
            TotalHp = totalHp,
            UnitList = units
        };

        return deckInfo;
    }
}