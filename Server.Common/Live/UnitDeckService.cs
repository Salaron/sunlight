using Microsoft.EntityFrameworkCore;
using Server.Database.Server;

namespace Server.Common.Live;

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
}