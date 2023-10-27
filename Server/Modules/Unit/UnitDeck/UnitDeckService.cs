using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Services.Unit;

internal class UnitDeckService : IUnitDeckService
{
    private readonly ServerDbContext _serverDbContext;

    public UnitDeckService(ServerDbContext serverDbContext)
    {
        _serverDbContext = serverDbContext;
    }

    public async Task<IEnumerable<UserUnitDeck>> GetUserDeckAsync(int userId)
    {
        var decks = await _serverDbContext.UserUnitDeck
            .Include(deck => deck.UnitOwningUserIds)
            .Where(deck => deck.UserId == userId)
            .ToListAsync();

        return decks;
    }
    
    public async Task<LiveShowDeckInfo> GetUserDeckForLiveShowAsync(int userId, int unitDeckId)
    {
        var deck = await _serverDbContext.UserUnitDeck
            .Include(deck => deck.UnitOwningUserIds)
            .ThenInclude(slot => slot.UnitOwningUser)
            .Where(deck => deck.UserId == userId && deck.UnitDeckId == unitDeckId)
            .FirstAsync();
        
        // TODO: accessories, school idol skills, etc...

        var units = new List<DeckSlotStat>();
        var totalSmile = 0;
        var totalPure = 0;
        var totalCool = 0;
        var totalHp = 0;
        foreach (var slot in deck.UnitOwningUserIds)
        {
            totalSmile += slot.UnitOwningUser.StatSmile;
            totalPure += slot.UnitOwningUser.StatPure;
            totalCool += slot.UnitOwningUser.StatCool;
            totalHp += slot.UnitOwningUser.MaxHp;
            units.Add(new DeckSlotStat
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

    public async Task SetDeckAsync(int userId, IEnumerable<UserUnitDeck> unitDecks)
    {
        var userDecks = _serverDbContext.UserUnitDeck.Where(u => u.UserId == userId);
        _serverDbContext.UserUnitDeck.RemoveRange(userDecks);
        
        await _serverDbContext.UserUnitDeck.AddRangeAsync(unitDecks);
        await _serverDbContext.SaveChangesAsync();
    }
}