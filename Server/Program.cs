using Server.Endpoints;
using Server.Startup;

WebApplication.CreateSlimBuilder(args)
    .AddConfig()
    .AddServices()
    .SetupDbContext()
    .Build()
    .UseMiddleware()
    .MapEndpoints()
    .Run();