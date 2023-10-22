using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Banner;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Banner;

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