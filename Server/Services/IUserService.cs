using SunLight.Database.Server;

namespace SunLight.Services;

public interface IUserService
{
    Task<User> GetUserInfoAsync(uint userId);
}