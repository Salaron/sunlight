using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Marathon;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/marathon")]
public class MarathonController : LlsifController
{
    [HttpPost("marathonInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult MarathonInfo([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}