namespace Server.Common.Crypto;

public interface ICryptoService : IDisposable
{
    byte[] DecryptRsa(string base64String);

    byte[] SignRsaSha1(string inputString);

    byte[] DecryptAes(byte[] key, byte[] data);

    string HmacSha1(string data, byte[] key);
}