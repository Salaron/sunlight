using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.MultiUnit;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.MultiUnit;

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