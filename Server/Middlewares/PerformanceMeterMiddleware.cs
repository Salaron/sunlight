using System.Diagnostics;

namespace SunLight.Middlewares;

internal class PerformanceMeterMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<PerformanceMeterMiddleware> _logger;

    public PerformanceMeterMiddleware(RequestDelegate next, ILogger<PerformanceMeterMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(httpContext);
            stopwatch.Stop();
            _logger.LogDebug($"Response generating took {stopwatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception has occurred while serving request");
            throw;
        }
    }
}