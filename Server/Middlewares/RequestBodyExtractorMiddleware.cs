namespace Server.Middlewares;

internal class RequestBodyExtractorMiddleware(RequestDelegate next, ILogger<RequestBodyExtractorMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext ctx)
    {
        if (ctx.Request.ContentType == null)
            return;

        // swagger/postman
        if (ctx.Request.ContentType.Contains("application/json"))
        {
            ctx.Request.EnableBuffering();
            ctx.Request.Body.Position = 0;
            using var streamReader = new StreamReader(ctx.Request.Body, leaveOpen: true);
            ctx.Items["RawRequestBody"] = await streamReader.ReadToEndAsync();
            ctx.Request.Body.Position = 0;
        }

        // game
        if (ctx.Request.ContentType.Contains("multipart/form-data"))
        {
            using var bodyReader = new StreamReader(ctx.Request.Body);
            var body = await bodyReader.ReadToEndAsync();
            var bodySplit = body.Split("\n");
            var requestBody = bodySplit[3];

            ctx.Request.Body = await new StringContent(requestBody).ReadAsStreamAsync();
            ctx.Request.ContentType = "application/json";
            ctx.Items["RawRequestBody"] = requestBody;
            ctx.SetEndpoint(null);
        }

        logger.LogDebug("{path}{newLine}{body}", ctx.Request.Path, Environment.NewLine, ctx.Items["RawRequestBody"]);

        await next(ctx);
    }
}