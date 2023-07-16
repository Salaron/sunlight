using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Request.Tutorial;
using SunLight.Dtos.Response;
using SunLight.Services;

namespace SunLight.Controllers;

/*
STATE = {
  START = 0,
  CHOOSE_CENTER_UNIT = 1,
  LIVE = 2,
  TOP = 3,
  END = -1
}
*/

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/tutorial")]
public class TutorialController : LlsifController
{
    private readonly IUserService _userService;

    public TutorialController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("progress")]
    [Produces(typeof(ServerResponse<EmptyResponse>))]
    public async Task<IActionResult> Progress([FromForm] TutorialProgressRequest request)
    {
        await _userService.UpdateTutorialStateAsync(UserId, request.TutorialState);

        return SendResponse(new EmptyResponse());
    }

    [HttpPost("skip")]
    [Produces(typeof(ServerResponse<EmptyResponse>))]
    public async Task<IActionResult> TosAgree([FromForm] ClientRequest request)
    {
        await _userService.UpdateTutorialStateAsync(UserId, -1);

        return SendResponse(new EmptyResponse());
    }
}