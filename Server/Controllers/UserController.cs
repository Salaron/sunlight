using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.User;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
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

    [XMessageCodeCheck]
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
}