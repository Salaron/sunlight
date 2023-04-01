using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SunLight.Database.Server;

namespace SunLight.Services;

internal class LoginService : ILoginService
{
    private const int KeySize = 32;
    private readonly ICryptoService _cryptoService;
    private readonly ServerDbContext _dbContext;

    public LoginService(ICryptoService cryptoService, ServerDbContext dbContext)
    {
        _cryptoService = cryptoService;
        _dbContext = dbContext;
    }

    public async Task<AuthKey> StartSessionAsync(string dummyToken)
    {
        var clientKey = _cryptoService.DecryptRsa(dummyToken);
        var serverKey = RandomNumberGenerator.GetBytes(KeySize);

        var sessionKey = new byte[KeySize];
        for (var i = 0; i < KeySize; i++)
        {
            sessionKey[i] = (byte)(clientKey[i] ^ serverKey[i]);
        }

        var userAuthKey = new AuthKey
        {
            AuthorizeToken = Guid.NewGuid(),
            SessionKey = Convert.ToBase64String(sessionKey),
            ServerKey = Convert.ToBase64String(serverKey)
        };

        await _dbContext.AddAsync(userAuthKey);
        await _dbContext.SaveChangesAsync();

        return userAuthKey;
    }

    public async Task<User> LoginAsync(string encryptedLogin, string encryptedPassword, Guid authorizeToken)
    {
        var (login, password) = await DecryptCredentialsAsync(authorizeToken, encryptedLogin, encryptedPassword);
        var selectedUser = await _dbContext.Users.FirstAsync(user =>
            user.LoginKey == login && user.LoginPasswd == password);

        var newAuthorizeToken = Guid.NewGuid();

        selectedUser.AuthorizeToken = newAuthorizeToken;
        selectedUser.LastLogin = DateTime.UtcNow;
        _dbContext.Update(selectedUser);
        await _dbContext.SaveChangesAsync();

        return selectedUser;
    }

    public async Task<User> RegisterAsync(string encryptedLogin, string encryptedPassword, Guid authorizeToken)
    {
        var (login, password) = await DecryptCredentialsAsync(authorizeToken, encryptedLogin, encryptedPassword);

        var newUser = new User
        {
            LoginKey = login,
            LoginPasswd = password,
            AuthorizeToken = Guid.NewGuid()
        };

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        return newUser;
    }

    private async Task<(string login, string password)> DecryptCredentialsAsync(Guid authorizeToken,
        string encryptedLogin, string encryptedPassword)
    {
        var userAuthKey = await _dbContext.AuthKeys.FirstAsync(key => key.AuthorizeToken == authorizeToken);

        var loginBytes = Convert.FromBase64String(encryptedLogin);
        var passwordBytes = Convert.FromBase64String(encryptedPassword);
        var sessionKeyBytes = Convert.FromBase64String(userAuthKey.SessionKey);

        var key = new byte[16];
        Array.Copy(sessionKeyBytes, 0, key, 0, 16);

        var decryptedLogin = Encoding.UTF8.GetString(_cryptoService.DecryptAes(key, loginBytes));
        var decryptedPassword = Encoding.UTF8.GetString(_cryptoService.DecryptAes(key, passwordBytes));

        return (decryptedLogin, decryptedPassword);
    }
}