using Microsoft.Extensions.DependencyInjection;
using Server.Common.Crypto;

namespace Server.Common;

public static class CommonModule
{
    public static void AddCommonModule(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICryptoService, CryptoService>();
    }
}