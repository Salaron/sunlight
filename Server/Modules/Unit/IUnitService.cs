using SunLight.Infrastructure.Database.Server;

namespace SunLight.Services.Unit;

public interface IUnitService
{
    Task<int> AddUnitToUserAsync(int userId, int unitId, int level = 1, int rank = 1);

    Task<IEnumerable<UnitOwning>> GetUnitsOwnedByUser(int userId);
}