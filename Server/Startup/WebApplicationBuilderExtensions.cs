using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Server.Common;
using Server.Common.Config;
using Server.Common.Json;
using Server.Database.Game;
using Server.Database.Server;
using Server.Endpoints;
using Server.Middlewares;

namespace Server.Startup;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddRouting();
        builder.Services.AddHttpContextAccessor();
        builder.Services.Configure<JsonOptions>(opts =>
        {
            opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            opts.SerializerOptions.Converters.Add(new DateTimeJsonConverter());
        });

        builder.Services.AddScoped<TransactionMiddleware>();
        builder.Services.AddCommonModule();
        builder.Services.AddEndpointsModule();
        builder.Services.AddEndpoints();

        return builder;
    }

    public static WebApplicationBuilder SetupDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ServerContext>(opts =>
        {
            var selectedDatabase =
                builder.Configuration["DatabaseBackend"] ?? throw new Exception("Database not provided");
            opts.UseNpgsql(builder.Configuration.GetConnectionString(selectedDatabase)).UseSnakeCaseNamingConvention();
        });

        builder.Services.AddDbContext<ItemContext>();
        builder.Services.AddDbContext<UnitContext>();
        builder.Services.AddDbContext<LiveContext>();
        builder.Services.AddDbContext<MuseumContext>();
        builder.Services.AddDbContext<LiveNotesContext>();
        
        return builder;
    }

    public static WebApplicationBuilder AddConfig(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddYamlFile("config.yml", optional: false, reloadOnChange: true);

        builder.Services.AddOptions<ServerConfig>()
            .Bind(builder.Configuration)
            .ValidateOnStart();

        return builder;
    }
}