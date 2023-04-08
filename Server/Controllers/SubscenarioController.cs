using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Subscenario;

namespace SunLight.Controllers;

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