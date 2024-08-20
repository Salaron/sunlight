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
}