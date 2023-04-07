using SunLight.Startup;

WebApplication.CreateBuilder(args)
    .AddYamlConfig()
    .RegisterServices()
    .SetupDbContext()
    .Build()
    .SetupMiddleware()
    .Run();