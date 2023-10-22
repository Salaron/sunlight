using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Challenge;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/challenge")]
public class ChallengeController : LlsifController
{
    [HttpPost("challengeInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult ChallengeInfo([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}