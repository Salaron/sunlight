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
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult SubScenarioStatus([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}