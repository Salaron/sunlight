﻿using Microsoft.AspNetCore.Authorization;
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
  END = -1,
  SKIPPING = 50,
  MERGE_FINISHED = 100,
  MUSE = {
    SCENARIO_1 = 2,
    LIVE = 3,
    SCENARIO_2 = 4,
    MERGE = 5,
    RANK_UP = 6,
    SCENARIO_3 = 7,
    TOP = 8
  },
  AQOURS = {
    SCENARIO_1 = 12,
    LIVE = 13,
    SCENARIO_2 = 14,
    MERGE = 15,
    SCENARIO_3 = 16,
    RANK_UP = 17,
    SCENARIO_4 = 18,
    SCENARIO_5 = 19,
    TOP = 20
  }
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