using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/album")]
public class AlbumController : LlsifController
{
    [HttpPost("albumAll")]
    public IActionResult AlbumAll([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();
        return SendResponse(response);
    }
}