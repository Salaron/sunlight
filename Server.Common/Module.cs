using Microsoft.Extensions.DependencyInjection;
using Server.Common.Crypto;
using Server.Common.Items;
using Server.Common.Login;

namespace Server.Common;

public static class CommonModule
{
    public static void AddCommonModule(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICryptoService, CryptoService>();
        serviceCollection.AddSingleton<IAuthKeyRepository, AuthKeyRepository>();
        serviceCollection.AddHostedService<AuthKeyRepository>();

        serviceCollection.AddScoped<IItemHandler, UnitHandler>();
    }
}