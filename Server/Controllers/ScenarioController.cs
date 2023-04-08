using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Scenario;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/scenario")]
public class ScenarioController : LlsifController
{
    [HttpPost("scenarioStatus")]
    [Produces(typeof(ServerResponse<ScenarioStatusResponse>))]
    public IActionResult ScenarioStatus([FromBody] ClientRequest requestData)
    {
        var response = new ScenarioStatusResponse
        {
            ScenarioStatusList = Enumerable.Empty<ScenarioStatusItem>()
        };

        return SendResponse(response);
    }
}