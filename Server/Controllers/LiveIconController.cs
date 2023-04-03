using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/liveicon")]
public class LiveIconController : LlsifController
{
    [HttpPost("liveiconInfo")]
    [BatchApiCall("liveicon", "liveiconInfo")]
    public IActionResult LiveIconInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}