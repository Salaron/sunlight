namespace Server.Middlewares;

internal class NotFoundMiddleware(RequestDelegate next, ILogger<NotFoundMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        await next(ctx);

        if (ctx.Response.StatusCode is 404)
        {
            logger.LogWarning("Unhandled:{newLine}{path}{newLine}{body}", Environment.NewLine, ctx.Request.Path,
                Environment.NewLine, ctx.Items["RawRequestBody"]);
        }
    }
}