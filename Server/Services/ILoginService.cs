using SunLight.Database.Server;

namespace SunLight.Services;

public interface ILoginService
{
    Task<AuthKey> StartSessionAsync(string dummyToken);

    Task<User> GetUserByTokenAsync(Guid authorizeToken);

    Task<User> LoginAsync(string encryptedLoginKey, string encryptedPassword, Guid authorizeToken);

    Task<User> RegisterAsync(string encryptedLoginKey, string encryptedPassword, Guid authorizeToken);
}