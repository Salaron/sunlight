using SunLight.Infrastructure.Database.Server;

namespace SunLight.Services.Live;

public interface ILiveStatusService
{
    Task<IEnumerable<LiveStatus>> GetNormalLiveStatusAsync(int userId);

    Task<IEnumerable<LiveStatus>> GetSpecialLiveStatusAsync(int userId);
}