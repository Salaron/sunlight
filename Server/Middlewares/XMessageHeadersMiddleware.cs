namespace SunLight.Middlewares;

internal class XMessageHeadersMiddleware
{
    private readonly RequestDelegate _next;

    public XMessageHeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        // check X-Message-Code here
        await _next(httpContext);
        // Add X-Message-Sign here
    }
}