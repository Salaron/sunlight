using Server.Common.Crypto;

namespace Server.Middlewares;

internal class MessageSignerMiddleware(ICryptoService cryptoService) : IMiddleware
{
    public async Task InvokeAsync(HttpContext ctx, RequestDelegate next)
    {
        var originalResponseBody = ctx.Response.Body;
        try
        {
            using var bufferedResponse = new MemoryStream();
            var hasXMessageCode = ctx.Request.Headers.TryGetValue("X-Message-Code", out var xMessageCode);
            if (hasXMessageCode)
                ctx.Response.Body = bufferedResponse;

            await next(ctx);

            if (hasXMessageCode)
            {
                ctx.Response.Body.Position = 0;
                var reader = new StreamReader(ctx.Response.Body, leaveOpen: true);
                var responseBody = await reader.ReadToEndAsync();
                ctx.Response.Body.Position = 0;

                var signature = cryptoService.SignRsaSha1(responseBody + xMessageCode);
                var xMessageSign = Convert.ToBase64String(signature);
                ctx.Response.Headers.Append("X-Message-Sign", xMessageSign);
                await bufferedResponse.CopyToAsync(originalResponseBody);
            }
        }
        catch (Exception)
        {
            ctx.Response.Body = originalResponseBody;
            throw;
        }
    }
}