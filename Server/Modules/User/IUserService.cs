using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.UserModule;

public interface IUserService
{
    Task<User> CreateUserAsync(string login, string password);

    Task<User> GetUserAsync(int userId);
    Task UpdateUserAsync(User user);
}