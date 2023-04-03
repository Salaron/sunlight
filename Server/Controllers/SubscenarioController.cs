using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/subscenario")]
public class SubscenarioController : LlsifController
{
    [HttpPost("subscenarioStatus")]
    [BatchApiCall("subscenario", "subscenarioStatus")]
    public IActionResult SubScenarioStatus([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}