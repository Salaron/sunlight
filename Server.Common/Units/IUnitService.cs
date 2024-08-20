using Server.Database.Server;

namespace Server.Common.Unit;

public interface IUnitService
{
    Task<List<UnitOwning>> GetUnitsAsync(int userId);
    
    Task<List<UnitAlbum>> GetAlbumAsync(int userId);
}