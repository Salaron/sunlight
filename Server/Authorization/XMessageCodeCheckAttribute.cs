using Microsoft.AspNetCore.Mvc.Filters;

namespace SunLight.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
internal class XMessageCodeCheckAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var requestBody = await ReadBodyAsStringAsync(context.HttpContext.Request);

        var hasXmcHeader =
            context.HttpContext.Request.Headers.TryGetValue("X-Message-Code", out var xMessageCodeHeader);

        await next();
    }

    private static async Task<string> ReadBodyAsStringAsync(HttpRequest request)
    {
        var initialBody = request.Body;

        try
        {
            var reader = new StreamReader(request.Body);
            var text = await reader.ReadToEndAsync();
            return text;
        }
        finally
        {
            request.Body = initialBody;
        }
    }
}