namespace SunLight.Infrastructure.Middlewares;

internal static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomResponseHeaders(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomResponseHeadersMiddleware>();
    }

    public static IApplicationBuilder UseNotFoundLogger(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<NotFoundLoggerMiddleware>();
    }

    public static IApplicationBuilder UseApiHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiRequestMiddleware>();
    }
}