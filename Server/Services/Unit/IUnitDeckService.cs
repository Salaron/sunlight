using SunLight.Database.Server;

namespace SunLight.Services.Unit;

public interface IUnitDeckService
{
    Task<IEnumerable<UserUnitDeck>> GetUserDeckAsync(int userId);

    Task<LivePlayDeckInfo> GetUserDeckForLiveShowAsync(int userId, int unitDeckId);

    Task CreateDeckAsync(int userId, string deckName, IEnumerable<int> unitOwningIds);
}