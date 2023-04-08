namespace SunLight.Services;

public interface IServerListenAddressProvider
{
    ICollection<string> GetAddress();
}