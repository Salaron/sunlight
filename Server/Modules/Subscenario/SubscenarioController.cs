using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Subscenario;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Subscenario;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/subscenario")]
public class SubscenarioController : LlsifController
{
    [HttpPost("subscenarioStatus")]
    [Produces(typeof(ServerResponse<SubscenarioStatusResponse>))]
    public IActionResult SubScenarioStatus([FromBody] ClientRequest requestData)
    {
        var response = new SubscenarioStatusResponse
        {
            SubscenarioStatusList = Enumerable.Empty<SubscenarioStatusItem>(),
            UnlockedSubscenarioIds = Enumerable.Empty<int>()
        };

        return SendResponse(response);
    }
}