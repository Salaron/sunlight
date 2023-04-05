using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/stamp")]
public class StampController : LlsifController
{
    [HttpPost("stampInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult StampInfo([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}