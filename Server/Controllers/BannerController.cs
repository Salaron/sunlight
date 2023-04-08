using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Banner;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/banner")]
public class BannerController : LlsifController
{
    [HttpPost("bannerList")]
    [Produces(typeof(ServerResponse<BannerListResponse>))]
    public IActionResult BannerList([FromBody] ClientRequest requestData)
    {
        var response = new BannerListResponse
        {
            TimeLimit = DateTime.MaxValue,
            BannerList = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }
}