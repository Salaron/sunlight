using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request.Login;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Login;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/login")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("authkey")]
    public async Task<ServerResponse<AuthKeyResponse>> AuthKeyAsync([FromBody] AuthKeyRequest requestData)
    {
        var userSession = await _loginService.StartSessionAsync(requestData.DummyToken);

        var response = new AuthKeyResponse
        {
            AuthorizeToken = userSession.AuthorizeToken.ToString(),
            DummyToken = userSession.ServerKey
        };

        return new ServerResponse<AuthKeyResponse>(response);
    }

    [XMessageCodeCheck]
    [HttpPost("login")]
    public LoginResponse LoginAsync([FromBody] LoginRequest requestData, [FromHeader] string authorize)
    {
        return new LoginResponse();
    }
}