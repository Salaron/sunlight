namespace SunLight.Middlewares;

internal static class MiddlewaresExtensions
{
    public static IApplicationBuilder UsePerformanceMeter(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<PerformanceMeterMiddleware>();
    }
    
    public static IApplicationBuilder UseXMessageHeaders(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<XMessageHeadersMiddleware>();
    }
}