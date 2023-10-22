using SunLight.Infrastructure.Database.Server;

namespace SunLight.Services.Unit;

public interface IUnitDeckService
{
    Task<IEnumerable<UserUnitDeck>> GetUserDeckAsync(int userId);

    Task<LiveShowDeckInfo> GetUserDeckForLiveShowAsync(int userId, int unitDeckId);

    Task CreateDeckAsync(int userId, string deckName, IEnumerable<int> unitOwningIds);
}