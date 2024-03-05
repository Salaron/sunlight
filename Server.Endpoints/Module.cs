using Microsoft.Extensions.DependencyInjection;
using Server.Common.Crypto;

namespace Server.Endpoints;

public static class EndpointsModule
{
    public static void AddEndpointsModule(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<XCodeVerifier>();
    }
}