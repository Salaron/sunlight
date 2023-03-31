using SunLight.Services;

namespace SunLight.Startup;

public static class ApplicationBuilderExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICryptoService, CryptoService>();
        serviceCollection.AddScoped<ILoginService, LoginService>();
    }
}