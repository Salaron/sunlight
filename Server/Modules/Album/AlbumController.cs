using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Album;

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