using SunLight.Infrastructure.Database.Game.Item;

namespace SunLight.Modules.Item;

public interface IItemService
{
    Task<IEnumerable<AwardM>> GetAwardAsync();

    Task<IEnumerable<BackgroundM>> GetBackgroundAsync();
}