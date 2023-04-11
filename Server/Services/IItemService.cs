using SunLight.Database.Game.Item;

namespace SunLight.Services;

public interface IItemService
{
    Task<IEnumerable<AwardM>> GetAwardAsync();

    Task<IEnumerable<BackgroundM>> GetBackgroundAsync();
}