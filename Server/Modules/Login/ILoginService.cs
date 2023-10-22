using SunLight.Dtos.Response.Login;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.Login;

public interface ILoginService
{
    Task<AuthKey> StartSessionAsync(string dummyToken);

    Task<Infrastructure.Database.Server.User> FindUserByTokenAsync(Guid authorizeToken);

    Task<Infrastructure.Database.Server.User> LoginAsync(string encryptedLoginKey, string encryptedPassword, Guid authorizeToken);

    Task<Infrastructure.Database.Server.User> RegisterAsync(string encryptedLoginKey, string encryptedPassword, Guid authorizeToken);

    LoginUnitListMemberCategory GetInitialUnitList(int memberCategory);

    Task<List<int>> CreateDefaultDeckAsync(int userId, int centerUnitId);
}