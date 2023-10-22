using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.PersonalNotice;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.PersonalNotice;

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