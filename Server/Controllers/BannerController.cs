using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/banner")]
public class BannerController : LlsifController
{
    [HttpPost("bannerList")]
    [BatchApiCall("banner", "bannerList")]
    public IActionResult BannerList([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}