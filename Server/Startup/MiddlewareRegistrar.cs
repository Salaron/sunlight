using SunLight.Middlewares;

namespace SunLight.Startup;

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

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCustomResponseHeaders();

        app.MapControllers();

        return app;
    }
}