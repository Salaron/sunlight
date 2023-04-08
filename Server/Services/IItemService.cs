using SunLight.Database.Game.Item;

namespace SunLight.Services;

public interface IItemService
{
    Task<IEnumerable<GameAwardInfo>> GetAwardAsync();

    Task<IEnumerable<GameBackgroundItem>> GetBackgroundAsync();
}