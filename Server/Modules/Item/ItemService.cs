using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Game;
using SunLight.Infrastructure.Database.Game.Item;

namespace SunLight.Modules.Item;

internal class ItemService : IItemService
{
    private readonly ItemDbContext _itemDbContext;

    public ItemService(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    public async Task<IEnumerable<AwardM>> GetAwardAsync()
    {
        return await _itemDbContext.AwardM.ToListAsync();
    }

    public async Task<IEnumerable<BackgroundM>> GetBackgroundAsync()
    {
        return await _itemDbContext.BackgroundM.ToListAsync();
    }
}