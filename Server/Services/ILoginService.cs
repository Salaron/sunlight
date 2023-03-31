using SunLight.Models;

namespace SunLight.Services;

public interface ILoginService
{
    Task<UserAuthKey> StartSessionAsync(string dummyToken);
}