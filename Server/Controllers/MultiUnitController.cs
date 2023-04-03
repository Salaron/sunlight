using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/multiunit")]
public class MultiUnitController : LlsifController
{
    [HttpPost("multiunitscenarioStatus")]
    [BatchApiCall("multiunit", "multiunitscenarioStatus")]
    public IActionResult MultiUnitScenarioStatus([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}