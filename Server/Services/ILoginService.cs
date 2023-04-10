using SunLight.Database.Server;
using SunLight.Dtos.Response.Login;

namespace SunLight.Services;

public interface ILoginService
{
    Task<AuthKey> StartSessionAsync(string dummyToken);

    Task<User> GetUserByTokenAsync(Guid authorizeToken);

    Task<User> LoginAsync(string encryptedLoginKey, string encryptedPassword, Guid authorizeToken);

    Task<User> RegisterAsync(string encryptedLoginKey, string encryptedPassword, Guid authorizeToken);

    LoginUnitListMemberCategory GetInitialUnitList(int memberCategory);

    Task<List<int>> CreateDefaultDeckAsync(int userId, int centerUnitId);
}