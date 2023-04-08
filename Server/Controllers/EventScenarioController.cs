using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.EventScenario;

namespace SunLight.Controllers;

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