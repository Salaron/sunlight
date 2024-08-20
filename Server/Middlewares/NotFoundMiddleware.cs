namespace Server.Middlewares;

internal class NotFoundMiddleware(ILogger<NotFoundMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);

        if (context.Response.StatusCode is 404)
        {
            logger.LogWarning("Unhandled:{newLine}{path}{newLine}{body}", Environment.NewLine, context.Request.Path,
                Environment.NewLine, context.Items["RawRequestBody"]);
        }
    }
}