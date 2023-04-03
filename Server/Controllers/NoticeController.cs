using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/notice")]
public class NoticeController : LlsifController
{
    [HttpPost("noticeMarquee")]
    [BatchApiCall("notice", "noticeMarquee")]
    public IActionResult NoticeMarquee([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}