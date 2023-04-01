using System.Security.Cryptography;
using System.Text;

namespace SunLight.Services;

internal class CryptoService : ICryptoService, IDisposable
{
    private const int RsaKeySize = 1024;
    private readonly RSACryptoServiceProvider _rsaCryptoServiceProvider = new(RsaKeySize);

    public CryptoService(IConfiguration configuration)
    {
        var privateKey = configuration["Server:RsaPrivateKey"] ??
                         throw new KeyNotFoundException("RSA public key not provided");
        _rsaCryptoServiceProvider.ImportFromPem(privateKey);
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

    public string HmacSha1(string data, string key)
    {
        return string.Empty;
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