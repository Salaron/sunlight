using SunLight.Infrastructure.Configuration;

namespace SunLight.Infrastructure.Startup;

internal static class YamlConfiguration
{
    public static WebApplicationBuilder AddYamlConfig(this WebApplicationBuilder builder)
    {
        Environment.SetEnvironmentVariable("LogsDir", AppContext.BaseDirectory);
        builder.Configuration.AddYamlFile("config.yml", optional: false, reloadOnChange: true);

        builder.Services.AddOptions<SunLightConfig>()
            .Bind(builder.Configuration)
            .ValidateOnStart();

        return builder;
    }
}