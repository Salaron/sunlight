using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace SunLight.Services;

internal class ServerListenAddressProvider : IServerListenAddressProvider
{
    private readonly ICollection<string> _addresses;

    public ServerListenAddressProvider(IServer server)
    {
        _addresses = server.Features.Get<IServerAddressesFeature>().Addresses;
    }

    public ICollection<string> GetAddress()
    {
        return _addresses;
    }
}