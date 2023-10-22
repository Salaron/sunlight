using SunLight.Infrastructure.Middlewares;

namespace SunLight.Infrastructure.Startup;

internal static class MiddlewareRegistrar
{
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Use(next => context =>
        {
            context.Request.EnableBuffering();
            return next(context);
        });
        app.UseNotFoundLogger();
        app.UseAuthentication();

        app.UseCustomResponseHeaders();
        app.UseApiHandler();

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}