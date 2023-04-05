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
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult EventScenarioStatus([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}