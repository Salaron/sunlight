namespace SunLight.Services;

public interface ICryptoService
{
    byte[] DecryptRsa(string base64String);
}