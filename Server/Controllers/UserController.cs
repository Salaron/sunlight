using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Request.User;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.User;
using SunLight.Services;

namespace SunLight.Controllers;

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
    public async Task<IActionResult> UserInfoAsync([FromForm] BaseRequest request)
    {
        var userInfo = await _userService.GetUserInfoAsync(1); // TODO
        var response = new UserInfoResponse
        {
            User = _mapper.Map<UserInfoDto>(userInfo)
        };

        return SendResponse(response);
    }

    [HttpPost("changeName")]
    [Produces(typeof(ServerResponse<ChangeNameResponse>))]
    public async Task<IActionResult> ChangeNameAsync([FromForm] ChangeNameRequest request)
    {
        await _userService.ChangeNameAsync(userId: 1, request.Name);

        var response = new ChangeNameResponse
        {
            BeforeName = "",
            AfterName = request.Name
        };

        return SendResponse(response);
    }

    [HttpPost("getNavi")]
    public IActionResult GetNavi([FromForm] BaseRequest request)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}