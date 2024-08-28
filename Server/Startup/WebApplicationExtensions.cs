using Server.Database.Server;
using Server.Middlewares;

namespace Server.Startup;

internal static class WebApplicationExtensions
{
    public static WebApplication UseMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionLoggerMiddleware>();
        app.UseMiddleware<RequestBodyExtractorMiddleware>();
        app.UseMiddleware<NotFoundMiddleware>();
        app.UseMiddleware<MessageSignerMiddleware>();
        app.UseMiddleware<TransactionMiddleware>();

        app.UseRouting();

        return app;
    }

    public static WebApplication SetupDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<ServerContext>();

        return app;
    }
}