using SunLight.Infrastructure.Startup;

WebApplication.CreateBuilder(args)
    .AddYamlConfig()
    .RegisterServices()
    .SetupDbContext()
    .Build()
    .SetupMiddleware()
    .Run();