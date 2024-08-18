using Server.Database.Server;

namespace Server.Common.Live;

public interface IUnitDeckService
{
    Task SetDeckListAsync(int userId, List<UserUnitDeck> deckList);
    Task<List<UserUnitDeck>> GetDeckListAsync(int userId);
}