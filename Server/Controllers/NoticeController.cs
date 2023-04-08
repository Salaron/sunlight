using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Notice;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/notice")]
public class NoticeController : LlsifController
{
    [HttpPost("noticeMarquee")]
    [Produces(typeof(ServerResponse<NoticeMarqueeResponse>))]
    public IActionResult NoticeMarquee([FromBody] ClientRequest requestData)
    {
        var response = new NoticeMarqueeResponse
        {
            ItemCount = 0,
            MarqueeList = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }
}