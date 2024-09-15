using Microsoft.EntityFrameworkCore;
using Server.Common.Unit;
using Server.Database.Server;

namespace Server.Common.Units;

internal class UnitService(ServerContext serverContext) : IUnitService
{
    public Task<List<UnitOwning>> GetUnitsAsync(int userId)
    {
        var units = serverContext.UnitOwning.Where(u => u.UserId == userId).ToListAsync();

        return units;
    }

    public Task<List<UnitAlbum>> GetAlbumAsync(int userId)
    {
        var units = serverContext.UnitAlbum.Where(a => a.UserId == userId).ToListAsync();

        return units;
    }

    public async Task<UnitOwning> GetCenterUnitAsync(int userId)
    {
        var mainDeck = await serverContext.UserUnitDeck.Include(d => d.UnitDeckSlots)
            .ThenInclude(s => s.UnitOwningUser)
            .Where(d => d.UserId == userId && d.MainFlag)
            .SingleAsync();

        return mainDeck.UnitDeckSlots[4].UnitOwningUser;
    }

    public async Task<UnitOwning> GetPartnerUnitAsync(int userId)
    {
        var user = await serverContext.Users.Include(u => u.PartnerUnit)
            .Where(u => u.UserId == userId)
            .SingleAsync();

        return user.PartnerUnit;
    }
}