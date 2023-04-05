using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/livese")]
public class LiveSeController : LlsifController
{
    [HttpPost("liveseInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult LiveSeInfo([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}