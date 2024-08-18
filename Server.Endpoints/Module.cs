using Microsoft.Extensions.DependencyInjection;

namespace Server.Endpoints;

public static class EndpointsModule
{
    public static void AddEndpointsModule(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<XCodeVerifier>();

        serviceCollection.AddScoped<IActionContext, ActionContext>();
    }
}