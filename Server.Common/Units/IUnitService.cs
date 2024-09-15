using Server.Database.Server;

namespace Server.Common.Unit;

public interface IUnitService
{
    Task<List<UnitOwning>> GetUnitsAsync(int userId);
    
    Task<List<UnitAlbum>> GetAlbumAsync(int userId);
    
    Task<UnitOwning> GetCenterUnitAsync(int userId);

    Task<UnitOwning> GetPartnerUnitAsync(int userId);
}