using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/multiunit")]
public class MuseumController : LlsifController
{
    [HttpPost("info")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult MuseumInfo([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}