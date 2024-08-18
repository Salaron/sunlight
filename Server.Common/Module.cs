using Microsoft.Extensions.DependencyInjection;
using Server.Common.Crypto;
using Server.Common.Download;
using Server.Common.Items;
using Server.Common.Live;
using Server.Common.Login;
using Server.Common.Unit;

namespace Server.Common;

public static class CommonModule
{
    public static void AddCommonModule(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICryptoService, CryptoService>();
        serviceCollection.AddSingleton<IDownloadService, NppsDownloadBackend>();
        serviceCollection.AddSingleton<ICredentialsHelper, CredentialsHelper>();
        serviceCollection.AddSingleton<IAuthKeyRepository, AuthKeyRepository>();
        serviceCollection.AddHostedService<AuthKeyRepository>();

        serviceCollection.AddScoped<IItemHandler, UnitHandler>();
        serviceCollection.AddScoped<ItemManager>();
        serviceCollection.AddScoped<IUnitDeckService, UnitDeckService>();
        serviceCollection.AddScoped<IUnitService, UnitService>();

    }
}