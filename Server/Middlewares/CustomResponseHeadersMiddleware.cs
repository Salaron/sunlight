using SunLight.Authorization;
using SunLight.Services;

namespace SunLight.Middlewares;

internal class CustomResponseHeadersMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ICryptoService _cryptoService;

    public CustomResponseHeadersMiddleware(RequestDelegate next, ICryptoService cryptoService)
    {
        _next = next;
        _cryptoService = cryptoService;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var hasXMessageCode = httpContext.Request.Headers.TryGetValue("X-Message-Code", out var xMessageCode);

        using var responseBody = new MemoryStream();
        var originalResponseBody = httpContext.Response.Body;

        try
        {
            httpContext.Response.Body = responseBody;

            await _next(httpContext);

            if (hasXMessageCode)
            {
                responseBody.Seek(offset: 0, SeekOrigin.Begin);
                var streamReader = new StreamReader(responseBody);

                var response = await streamReader.ReadToEndAsync();
                var signature = _cryptoService.SignRsaSha1(response + xMessageCode);
                var xMessageSign = Convert.ToBase64String(signature);

                httpContext.Response.Headers.Add("X-Message-Sign", xMessageSign);
            }

            httpContext.Response.Headers.Add("user_id", "");
            httpContext.Response.Headers.Add("version_up", "0");
            httpContext.Response.Headers.Add("authorize", new AuthorizeHeader().ToString());
        }
        finally
        {
            responseBody.Seek(offset: 0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalResponseBody);
        }
    }
}