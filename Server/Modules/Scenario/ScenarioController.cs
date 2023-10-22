using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Scenario;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Scenario;

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