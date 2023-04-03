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
    [BatchApiCall("album", "albumAll")]
    public IActionResult AlbumAll([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}