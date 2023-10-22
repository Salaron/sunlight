using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using SunLight.Dtos.Response;

namespace SunLight.Infrastructure.Middlewares;

internal class ApiRequestMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiRequestMiddleware> _logger;

    public ApiRequestMiddleware(RequestDelegate next, ILogger<ApiRequestMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.Path == "/main.php/api")
        {
            var body = await GetDeserializedBody(httpContext);
            httpContext.Request.ContentType = "application/json";

            var response = new List<ApiResponse>();
            var originalResponseBody = httpContext.Response.Body;

            foreach (var request in body.AsArray())
            {
                request["commandNum"] = "";
                request["mdg"] = 1;
                using var newRequestBody = new MemoryStream(Encoding.UTF8.GetBytes(request.ToJsonString()));
                using var newResponseBody = new MemoryStream();
                httpContext.Request.Path = $"/main.php/{request["module"]}/{request["action"]}";
                httpContext.Request.Body = newRequestBody;
                httpContext.Response.Body = newResponseBody;
                httpContext.Response.ContentType = null;
                httpContext.SetEndpoint(null);

                try
                {
                    await _next(httpContext);

                    newResponseBody.Seek(offset: 0, SeekOrigin.Begin);
                    using var streamReader = new StreamReader(newResponseBody);
                    var responseBody = await streamReader.ReadToEndAsync();
                    var responseJson = JsonNode.Parse(responseBody)!;
                    var val = responseJson["response_data"];
                    response.Add(new ApiResponse(val));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Batch API error");
                    response.Add(new ApiResponse(new ErrorResponse(500, ex.Message), 600));
                }

            }

            var responseData = new ServerResponse<IEnumerable<ApiResponse>>(response, 200);
            var serializedResponseData = JsonSerializer.Serialize(responseData, JsonSerializerDefaultOptions.GetOptions());
            httpContext.Response.Body = originalResponseBody;
            await httpContext.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(serializedResponseData));
        }
        else
        {
            await _next(httpContext);
        }
    }


    private async Task<JsonNode> GetDeserializedBody(HttpContext httpContext)
    {
        if (httpContext.Request.HasJsonContentType())
        {
            using var bodyReader = new StreamReader(httpContext.Request.Body);
            var body = await bodyReader.ReadToEndAsync();
            return JsonNode.Parse(body);
        }

        if (httpContext.Request.ContentType?.Contains("multipart/form-data") == true)
        {
            using var bodyReader = new StreamReader(httpContext.Request.Body);
            var body = await bodyReader.ReadToEndAsync();
            var splittedBody = body.Split("\n");
            return JsonNode.Parse(splittedBody[3]);
        }

        throw new Exception("Failed to deserialize body");
    }
}