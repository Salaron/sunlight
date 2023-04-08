using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.MultiUnit;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/multiunit")]
public class MultiUnitController : LlsifController
{
    [HttpPost("multiunitscenarioStatus")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult MultiUnitScenarioStatus([FromBody] ClientRequest requestData)
    {
        var response = new MultiUnitScenarioStatusResponse
        {
            MultiUnitScenarioStatusList = Enumerable.Empty<MultiUnitScenarioItem>()
        };

        return SendResponse(response);
    }
}