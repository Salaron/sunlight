using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.PersonalNotice;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/personalnotice")]
public class PersonalNoticeController : LlsifController
{
    [HttpPost("get")]
    [Produces(typeof(ServerResponse<PersonalNoticeGetResponse>))]
    public IActionResult GetPersonalNotice([FromBody] ClientRequest requestData)
    {
        var response = new PersonalNoticeGetResponse
        {
            HasNotice = false,
            NoticeId = 0,
            Type = 0,
            Title = "",
            Contents = ""
        };

        return SendResponse(response);
    }
}