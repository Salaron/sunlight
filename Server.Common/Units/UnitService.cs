using Microsoft.EntityFrameworkCore;
using Server.Database.Server;

namespace Server.Common.Unit;

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
}