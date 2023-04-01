namespace SunLight.Services;

public interface ICryptoService
{
    byte[] DecryptRsa(string base64String);

    byte[] SignRsaSha1(string inputString);
}