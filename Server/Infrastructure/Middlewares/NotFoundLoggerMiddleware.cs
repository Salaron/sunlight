using System.Net;

namespace SunLight.Infrastructure.Middlewares;

internal class NotFoundLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<NotFoundLoggerMiddleware> _logger;

    public NotFoundLoggerMiddleware(RequestDelegate next, ILogger<NotFoundLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await _next(httpContext);

        if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
        {
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            using var requestBodyStreamReader = new StreamReader(httpContext.Request.Body);
            var requestBody = await requestBodyStreamReader.ReadToEndAsync();
            _logger.LogWarning(
                $"Handler for {httpContext.Request.Path} is not implemented" +
                Environment.NewLine +
                $"Request body was {requestBody}");
        }
    }
}