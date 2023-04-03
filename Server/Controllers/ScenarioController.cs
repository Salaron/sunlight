using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/scenario")]
public class ScenarioController : LlsifController
{
    [HttpPost("scenarioStatus")]
    [BatchApiCall("scenario", "scenarioStatus")]
    public IActionResult ScenarioStatus([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}