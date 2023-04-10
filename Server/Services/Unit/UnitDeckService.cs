using Microsoft.EntityFrameworkCore;
using SunLight.Database.Server;

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

    public async Task CreateDeckAsync(int userId, string deckName, IEnumerable<int> unitOwningIds)
    {
        var newDeck = new UserUnitDeck
        {
            DeckName = deckName,
            UnitDeckId = 1,
            UserId = userId,
            UnitOwningUserIds = unitOwningIds.Select((u, i) => new UserUnitDeckSlot
            {
                Position = i + 1,
                UnitOwningUserId = u
            }).ToList()
        };

        await _serverDbContext.UserUnitDeck.AddAsync(newDeck);
        await _serverDbContext.SaveChangesAsync();
    }
}