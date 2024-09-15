using Server.Common.Live;
using Server.Database.Server;

namespace Server.Common.Units;

public interface IUnitDeckService
{
    Task SetDeckListAsync(int userId, List<UserUnitDeck> deckList);
    Task<List<UserUnitDeck>> GetDeckListAsync(int userId);
    Task<LiveShowDeckInfo> GetDeckForLiveShowAsync(int userId, int unitDeckId);
}