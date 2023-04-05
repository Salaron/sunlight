using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/api")]
[Produces("application/json")]
public class ApiController : LlsifController
{
    private readonly ILogger<ApiController> _logger;
    private readonly IConfiguration _configuration;

    private static readonly HttpClient _httpClient = new();

    public ApiController(ILogger<ApiController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [HttpPost]
    [XMessageCodeCheck]
    [Produces(typeof(ServerResponse<List<ApiResponse>>))]
    public async Task<IActionResult> CallApiAsync([FromBody] IEnumerable<ClientApiRequest> modules)
    {
        var response = new List<ApiResponse>();

        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = 5
        };

        await Parallel.ForEachAsync(modules, options, async (module, token) =>
        {
            var serverUrl = _configuration["Kestrel:Https:Url"];
            var queryUrl = $"{module.Module}/{module.Action}";

            _logger.LogDebug("Executing");
            var request = new ClientRequest
            {
                Module = module.Module,
                Action = module.Action,
                TimeStamp = module.TimeStamp,
                Mgd = GameMode.Muse,
                CommandNum = ""
            };

            using var requestBody =
                new StringContent(JsonSerializer.Serialize(request), Encoding.Default, "application/json");
            var rs = await _httpClient.PostAsync($"{serverUrl}/main.php/{queryUrl}", requestBody, token);
            var responseBodyStream = await rs.Content.ReadAsStreamAsync(token);

            var parsedResponse =
                await JsonSerializer.DeserializeAsync<ServerResponse<object>>(responseBodyStream,
                    cancellationToken: token);
            response.Add(new ApiResponse(parsedResponse.ResponseData));
        });

        return SendResponse(response);
    }
}