using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SunLight.Authentication;
using SunLight.Database.Game;
using SunLight.Database.Server;
using SunLight.Dtos;
using SunLight.LiveShow;
using SunLight.Services;
using SunLight.Services.Live;
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

        builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUnitDeckService, UnitDeckService>();
        builder.Services.AddScoped<IUnitService, UnitService>();
        builder.Services.AddScoped<IItemService, ItemService>();

        builder.Services.AddScoped<ILiveNotesService, LiveNotesService>();
        builder.Services.AddScoped<ILiveInfoProvider, LiveInfoProvider>();

        builder.Services.AddScoped<ILiveShowStarter, LiveShowStarter>();


        builder.Services.AddScoped<ILiveStatusService, LiveStatusService>();

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
        builder.Services.AddDbContext<LiveDbContext>();
        builder.Services.AddDbContext<MuseumDbContext>();
        builder.Services.AddDbContext<LiveNotesDbContext>();

        return builder;
    }
}