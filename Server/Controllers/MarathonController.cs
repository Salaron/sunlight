using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/marathon")]
public class MarathonController : LlsifController
{
    [HttpPost("marathonInfo")]
    [BatchApiCall("marathon", "marathonInfo")]
    public IActionResult MarathonInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}