﻿namespace SunLight.Startup;

internal static class YamlConfiguration
{
    public static WebApplicationBuilder AddYamlConfig(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddYamlFile("config.yml", optional: false);

        return builder;
    }
}