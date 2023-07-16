using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request.Common;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/common")]
public class CommonController : LlsifController
{
    [HttpPost("liveResume")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult LiveResume([FromBody] LiveResumeRequest requestData)
    {
        // TODO: remove live progress record from the database
        return SendResponse(Enumerable.Empty<EmptyResponse>());
    }
}