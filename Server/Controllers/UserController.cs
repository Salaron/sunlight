using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Request.User;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.User;
using SunLight.Services;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/user")]
public class UserController : LlsifController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("userInfo")]
    [Produces(typeof(ServerResponse<UserInfoResponse>))]
    public async Task<IActionResult> UserInfoAsync([FromForm] ClientRequest request)
    {
        var userInfo = await _userService.GetUserInfoAsync(UserId);
        var response = new UserInfoResponse
        {
            User = _mapper.Map<UserInfoDto>(userInfo),
            Birth = null,
            AdStatus = false
        };

        return SendResponse(response);
    }

    [HttpPost("changeName")]
    [Produces(typeof(ServerResponse<ChangeNameResponse>))]
    public async Task<IActionResult> ChangeNameAsync([FromForm] ChangeNameRequest request)
    {
        await _userService.ChangeNameAsync(UserId, request.Name);

        var response = new ChangeNameResponse
        {
            BeforeName = "",
            AfterName = request.Name
        };

        return SendResponse(response);
    }

    [HttpPost("getNavi")]
    [Produces(typeof(ServerResponse<UserGetNaviRequest>))]
    public async Task<IActionResult> GetNavi([FromForm] ClientRequest request)
    {
        var userInfo = await _userService.GetUserInfoAsync(UserId);
        var response = new UserGetNaviRequest
        {
            User = new UserGetNaviRequest.UserNavi
            {
                UserId = userInfo.UserId,
                UnitOwningUserId = userInfo.PartnerUnitId ?? 0
            }
        };

        return SendResponse(response);
    }
}