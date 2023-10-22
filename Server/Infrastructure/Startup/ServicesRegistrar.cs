using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SunLight.Dtos;
using SunLight.Infrastructure.Authentication;
using SunLight.Infrastructure.Database.Game;
using SunLight.Infrastructure.Database.Server;
using SunLight.Infrastructure.Json;
using SunLight.Infrastructure.Security;
using SunLight.Modules.Download;
using SunLight.Modules.Item;
using SunLight.Modules.Live.LiveShow;
using SunLight.Modules.Login;
using SunLight.Modules.UserModule;
using SunLight.Services.Live;
using SunLight.Services.Unit;

namespace SunLight.Infrastructure.Startup;

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
                opts.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
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
        
        builder.Services.AddScoped<IDownloadService, NppsDownloadBackend>();


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