using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Request.Tutorial;
using SunLight.Dtos.Response;
using SunLight.Infrastructure.Authorization;
using SunLight.Modules.UserModule;

namespace SunLight.Modules.Tutorial;

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
        var user = await _userService.GetUserAsync(UserId);
        user.TutorialState = request.TutorialState;
        await _userService.UpdateUserAsync(user);

        return SendResponse(new EmptyResponse());
    }

    [HttpPost("skip")]
    [Produces(typeof(ServerResponse<EmptyResponse>))]
    public async Task<IActionResult> Skip([FromForm] ClientRequest request)
    {
        var user = await _userService.GetUserAsync(UserId);
        user.TutorialState = -1;
        await _userService.UpdateUserAsync(user);

        return SendResponse(new EmptyResponse());
    }
}