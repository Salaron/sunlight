namespace Server.Middlewares;

internal class RequestBodyExtractorMiddleware(ILogger<RequestBodyExtractorMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.ContentType == null)
            return;

        // swagger/postman
        if (context.Request.ContentType.Contains("application/json"))
        {
            context.Request.EnableBuffering();
            context.Request.Body.Position = 0;
            using var streamReader = new StreamReader(context.Request.Body, leaveOpen: true);
            context.Items["RawRequestBody"] = await streamReader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }

        // game
        if (context.Request.ContentType.Contains("multipart/form-data"))
        {
            using var bodyReader = new StreamReader(context.Request.Body);
            var body = await bodyReader.ReadToEndAsync();
            var bodySplit = body.Split("\r\n");
            var requestBody = bodySplit[3];

            context.Request.Body = await new StringContent(requestBody).ReadAsStreamAsync();
            context.Request.ContentType = "application/json";
            context.Items["RawRequestBody"] = requestBody;
            context.SetEndpoint(null);
        }

        logger.LogTrace("{path}{newLine}{body}", context.Request.Path, Environment.NewLine, context.Items["RawRequestBody"]);

        await next(context);
    }
}