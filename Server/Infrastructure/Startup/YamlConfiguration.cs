using SunLight.Infrastructure.Configuration;

namespace SunLight.Infrastructure.Startup;

internal static class YamlConfiguration
{
    public static WebApplicationBuilder AddYamlConfig(this WebApplicationBuilder builder)
    {
        // TODO: config validation
        builder.Configuration.AddYamlFile("config.yml", optional: false, reloadOnChange: true);

        builder.Services.AddOptions<ServerConfig>()
            .Bind(builder.Configuration)
            .ValidateOnStart();

        return builder;
    }
}