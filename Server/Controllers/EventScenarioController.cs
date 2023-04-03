using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/eventscenario")]
public class EventScenarioController : LlsifController
{
    [HttpPost("status")]
    [BatchApiCall("eventscenario", "status")]
    public IActionResult EventScenarioStatus([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}