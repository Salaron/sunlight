using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Login;
using SunLight.Dtos.Request.Login;
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
    public async Task<AuthKeyResponse> AuthKeyAsync([FromBody] AuthKeyRequest requestData)
    {
        var userSession = await _loginService.StartSessionAsync(requestData.DummyToken);

        return new AuthKeyResponse
        {
            AuthorizeToken = userSession.AuthorizeToken.ToString(),
            DummyToken = userSession.ServerKey
        };
    }

    [HttpPost("login")]
    public LoginResponse LoginAsync([FromBody] LoginRequest requestData, [FromHeader] string authorize)
    {
        return new LoginResponse();
    }
}