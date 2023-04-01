using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SunLight.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
internal class XMessageCodeCheckAttribute : Attribute, IAsyncActionFilter
{
    private readonly bool _performCheck;

    public XMessageCodeCheckAttribute(bool performCheck = true)
    {
        _performCheck = performCheck;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (_performCheck)
        {
            var requestBody = JsonSerializer.Serialize(context.ModelState.Root.RawValue);

            var hasXmcHeader =
                context.HttpContext.Request.Headers.TryGetValue("X-Message-Code", out var xMessageCodeHeader);
        }

        await next();
    }
}