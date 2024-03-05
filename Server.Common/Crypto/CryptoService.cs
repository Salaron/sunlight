using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Server.Common.Config;

namespace Server.Common.Crypto;

internal class CryptoService : ICryptoService
{
    private const int RsaKeySize = 1024;
    private readonly RSACryptoServiceProvider _rsaCryptoServiceProvider = new(RsaKeySize);

    public CryptoService(IOptions<ServerConfig> serverConfig)
    {
        _rsaCryptoServiceProvider.ImportFromPem(serverConfig.Value.RsaPrivateKey);
    }

    public byte[] DecryptRsa(string base64String)
    {
        var resultBytes = Convert.FromBase64String(base64String);
        var decryptedBytes = _rsaCryptoServiceProvider.Decrypt(resultBytes, fOAEP: false);
        return decryptedBytes;
    }

    public byte[] SignRsaSha1(string dataToSign)
    {
        var bytesToSign = Encoding.UTF8.GetBytes(dataToSign);
        var signatureBytes =
            _rsaCryptoServiceProvider.SignData(bytesToSign, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);

        return signatureBytes;
    }

    public string HmacSha1(string data, byte[] key)
    {
        using var hmac = new HMACSHA1(key);
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

        return hashString;
    }

    public byte[] DecryptAes(byte[] key, byte[] data)
    {
        using var aes = Aes.Create();
        var iv = new byte[16];
        Array.Copy(data, 0, iv, 0, 16);
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        var cipher = aes.CreateDecryptor(aes.Key, aes.IV);

        return cipher.TransformFinalBlock(data, 16, data.Length - 16);
    }

    public void Dispose()
    {
        _rsaCryptoServiceProvider.Dispose();
    }
}