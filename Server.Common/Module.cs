using Microsoft.Extensions.DependencyInjection;
using Server.Common.Crypto;
using Server.Common.Download;
using Server.Common.Items;
using Server.Common.Live;
using Server.Common.Login;
using Server.Common.Tutorial;
using Server.Common.Unit;
using Server.Common.Users;

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

        serviceCollection.AddScoped<IAddTypeHandler, UnitHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, LovecaHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, SocialPointHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, PlayerExpHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, GameCoinHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, AwardHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, BackgroundHandler>();
        serviceCollection.AddScoped<IAddTypeHandler, LiveHandler>();
        serviceCollection.AddScoped<ItemManager>();
        serviceCollection.AddScoped<IUnitDeckService, UnitDeckService>();
        serviceCollection.AddScoped<IUnitService, UnitService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IInitialItemsUnlocker, InitialItemsUnlocker>();
        serviceCollection.AddScoped<ILiveStatusProvider, LiveStatusProvider>();
        serviceCollection.AddScoped<ITutorialService, TutorialService>();
        serviceCollection.AddScoped<IUnlockedItemsProvider, UnlockedItemsProvider>();
    }
}