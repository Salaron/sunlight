using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SunLight.Authentication;
using SunLight.Database.Game;
using SunLight.Database.Server;
using SunLight.Dtos;
using SunLight.Services;
using SunLight.Services.Unit;

namespace SunLight.Startup;

internal static class ServicesRegistrar
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication()
            .AddScheme<HeaderAuthenticationOptions, HeaderAuthenticationHandler>(
                "AuthorizeHeaderAuthentication",
                opts => { });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services
            .AddControllers(opts => opts.ModelBinderProviders.Insert(0, new RequestDataBinderProvider()))
            .AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
                opts.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });

        builder.Services.AddRouting();

        builder.Services.AddSingleton<ICryptoService, CryptoService>();
        builder.Services.AddSingleton<IServerListenAddressProvider, ServerListenAddressProvider>();

        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUnitService, UnitService>();
        builder.Services.AddScoped<IItemService, ItemService>();

        return builder;
    }

    public static WebApplicationBuilder SetupDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ServerDbContext>(opts =>
        {
            var selectedDatabase =
                builder.Configuration["Server:Database"] ?? throw new Exception("Database not provided");
            opts.UseNpgsql(builder.Configuration.GetConnectionString(selectedDatabase)).UseSnakeCaseNamingConvention();
        });

        builder.Services.AddDbContext<ItemDbContext>();
        builder.Services.AddDbContext<UnitDbContext>();

        return builder;
    }
}