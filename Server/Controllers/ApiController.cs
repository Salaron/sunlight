using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/api")]
public class ApiController : LlsifController
{
    private readonly ILogger<ApiController> _logger;
    private readonly IServerListenAddressProvider _listenAddressProvider;
    private static readonly HttpClient Client = new();

    public ApiController(ILogger<ApiController> logger, IServerListenAddressProvider listenAddressProvider)
    {
        _logger = logger;
        _listenAddressProvider = listenAddressProvider;
    }

    [HttpPost]
    [XMessageCodeCheck]
    [Produces(typeof(ServerResponse<List<ApiResponse>>))]
    public async Task<IActionResult> CallApiAsync([FromBody] IEnumerable<ClientApiRequest> apiRequests)
    {
        // Because of the limitations of the ASP.NET platform, we cannot directly call a controller method
        // (no, actually we can, but then there would be a lot of problems),
        // so the batch API is handled through a proxy server call to itself.
        var response = new List<ApiResponse>();

        var serverAddress = _listenAddressProvider.GetAddress()
            .First()
            .Replace("0.0.0.0", "localhost");

        foreach (var apiRequest in apiRequests)
        {
            try
            {
                var queryUrl = $"{apiRequest.Module}/{apiRequest.Action}";

                _logger.LogDebug($"Serving batch API request for {queryUrl}");
                var request = new ClientRequest
                {
                    Module = apiRequest.Module,
                    Action = apiRequest.Action,
                    TimeStamp = apiRequest.TimeStamp,
                    Mgd = GameMode.Muse,
                    CommandNum = ""
                };
                // TODO: XMC calculation, header copy

                using var requestBody =
                    new StringContent(JsonSerializer.Serialize(request), Encoding.Default, "application/json");

                var httpRequestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{serverAddress}/main.php/{queryUrl}"),
                    Content = requestBody,
                    Method = HttpMethod.Post
                };
                httpRequestMessage.Headers.Add("Authorize", Request.Headers["Authorize"].First());

                var serverResponse = await Client.SendAsync(httpRequestMessage);
                serverResponse.EnsureSuccessStatusCode();
                var responseBody = await serverResponse.Content.ReadAsStringAsync();

                var responseJson = JsonNode.Parse(responseBody)!;

                var val = responseJson["response_data"];
                response.Add(new ApiResponse(val));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Batch API request error");
                response.Add(new ApiResponse(new ErrorResponse(1234), 600));
            }
        }

        return SendResponse(response);
    }
}