using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/challenge")]
public class ChallengeController : LlsifController
{
    [HttpPost("challengeInfo")]
    [BatchApiCall("challenge", "challengeInfo")]
    public IActionResult ChallengeInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}