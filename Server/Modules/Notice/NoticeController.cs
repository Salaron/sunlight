using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Notice;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Notice;

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