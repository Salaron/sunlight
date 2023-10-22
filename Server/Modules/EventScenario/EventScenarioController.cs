using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.EventScenario;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.EventScenario;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/eventscenario")]
public class EventScenarioController : LlsifController
{
    [HttpPost("status")]
    [Produces(typeof(ServerResponse<EventScenarioStatusResponse>))]
    public IActionResult EventScenarioStatus([FromBody] ClientRequest requestData)
    {
        var response = new EventScenarioStatusResponse
        {
            EventScenarioList = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }
}