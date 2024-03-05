using Server.Common.Crypto;

namespace Server.Middlewares;

internal class MessageSignerMiddleware(RequestDelegate next, ICryptoService cryptoService)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        var originalResponseBody = ctx.Response.Body;
        using var bufferedResponse = new MemoryStream();
        var hasXMessageCode = ctx.Request.Headers.TryGetValue("X-Message-Code", out var xMessageCode);
        if (hasXMessageCode)
        {
            ctx.Response.Body = bufferedResponse;
        }

        await next(ctx);

        // time to flex
        ctx.Response.Headers.Append("X-Powered-By", "SunLight Project v4");
        if (hasXMessageCode)
        {
            ctx.Response.Body.Position = 0;
            var reader = new StreamReader(ctx.Response.Body, leaveOpen: true);
            var responseBody = await reader.ReadToEndAsync();
            ctx.Response.Body.Position = 0;

            var signature = cryptoService.SignRsaSha1(responseBody + xMessageCode);
            var xMessageSign = Convert.ToBase64String(signature);
            ctx.Response.Headers.Append("X-Message-Sign", xMessageSign);
        }

        await bufferedResponse.CopyToAsync(originalResponseBody);
    }
}