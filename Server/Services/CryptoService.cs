using System.Security.Cryptography;

namespace SunLight.Services;

internal class CryptoService : ICryptoService
{
    private const int RsaKeySize = 1024;
    private readonly string _privateKey;

    public CryptoService(IConfiguration configuration)
    {
        _privateKey = configuration["server:rsa_private_key"] ?? string.Empty;
    }

    public byte[] DecryptRsa(string base64String)
    {
        using var rsa = new RSACryptoServiceProvider(RsaKeySize);
        try
        {
            rsa.ImportFromPem(_privateKey);

            var resultBytes = Convert.FromBase64String(base64String);
            var decryptedBytes = rsa.Decrypt(resultBytes, fOAEP: false);
            return decryptedBytes;
        }
        finally
        {
            rsa.PersistKeyInCsp = false;
        }
    }
}