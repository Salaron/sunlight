namespace SunLight.Services;

public interface ICryptoService : IDisposable
{
    byte[] DecryptRsa(string base64String);

    byte[] SignRsaSha1(string inputString);

    byte[] DecryptAes(byte[] key, byte[] data);
}