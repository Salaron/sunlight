namespace Server.Middlewares;

internal class ExceptionLoggerMiddleware(ILogger<ExceptionLoggerMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BadHttpRequestException ex)
        {
            logger.LogDebug(ex, "Incorrect request");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Top-level exception occured");
        }
    }
}