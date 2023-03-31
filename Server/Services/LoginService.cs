using System.Security.Cryptography;
using SunLight.Models;

namespace SunLight.Services;

internal class LoginService : ILoginService
{
    private const int KeySize = 32;
    private readonly ICryptoService _cryptoService;

    public LoginService(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    public async Task<UserAuthKey> StartSessionAsync(string dummyToken)
    {
        var clientKey = _cryptoService.DecryptRsa(dummyToken);
        var serverKey = RandomNumberGenerator.GetBytes(KeySize);

        var sessionKey = new byte[KeySize];
        for (var i = 0; i < KeySize; i++)
        {
            sessionKey[i] = (byte)(clientKey[i] ^ serverKey[i]);
        }

        var userAuthKey = new UserAuthKey
        {
            AuthorizeToken = Guid.NewGuid(),
            SessionKey = Convert.ToBase64String(sessionKey),
            ServerKey = Convert.ToBase64String(serverKey)
        };

        return userAuthKey;
    }
}