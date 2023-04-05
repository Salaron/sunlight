using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/costume")]
public class CostumeController : LlsifController
{
    [HttpPost("costumeList")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult Event([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();
        return SendResponse(response);
    }
}