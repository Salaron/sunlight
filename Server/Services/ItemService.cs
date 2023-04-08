using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game;
using SunLight.Database.Game.Item;

namespace SunLight.Services;

internal class ItemService : IItemService
{
    private readonly ItemDbContext _itemDbContext;

    public ItemService(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    public async Task<IEnumerable<GameAwardInfo>> GetAwardAsync()
    {
        return await _itemDbContext.AwardM.ToListAsync();
    }

    public async Task<IEnumerable<GameBackgroundItem>> GetBackgroundAsync()
    {
        return await _itemDbContext.BackgroundM.ToListAsync();
    }
}