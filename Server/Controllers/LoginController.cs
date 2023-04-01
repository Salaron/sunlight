using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request.Login;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Login;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/login")]
public class LoginController : LlsifController
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("authkey")]
    [Produces(typeof(ServerResponse<AuthKeyResponse>))]
    public async Task<IActionResult> AuthKeyAsync([FromBody] AuthKeyRequest requestData)
    {
        var userSession = await _loginService.StartSessionAsync(requestData.DummyToken);

        var response = new AuthKeyResponse
        {
            AuthorizeToken = userSession.AuthorizeToken.ToString(),
            DummyToken = userSession.ServerKey
        };

        return SendResponse(response);
    }

    [XMessageCodeCheck]
    [HttpPost("login")]
    [Produces(typeof(ServerResponse<LoginResponse>))]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest requestData, [FromHeader] string authorize)
    {
        var parsedAuthorizeHeader = AuthorizeHeader.FromString(authorize);

        try
        {
            var authenticatedUser =
                await _loginService.LoginAsync(requestData.LoginKey, requestData.LoginPasswd,
                    parsedAuthorizeHeader.Token);

            var response = new LoginResponse
            {
                AuthorizeToken = authenticatedUser.AuthorizeToken.ToString(),
                UserId = authenticatedUser.UserId,
                IdfaEnabled = false,
                SkipLoginNews = true
            };

            return SendResponse(response);
        }
        catch (Exception)
        {
            return SendResponse(new ErrorResponse(errorCode: 407), jsonStatusCode: 600);
        }
    }

    [XMessageCodeCheck]
    [HttpPost("startup")]
    [Produces(typeof(ServerResponse<LoginResponse>))]
    public async Task<IActionResult> StartUpAsync([FromBody] LoginRequest requestData, [FromHeader] string authorize)
    {
        var parsedAuthorizeHeader = AuthorizeHeader.FromString(authorize);

        try
        {
            var authenticatedUser =
                await _loginService.RegisterAsync(requestData.LoginKey, requestData.LoginPasswd,
                    parsedAuthorizeHeader.Token);

            var response = new LoginResponse
            {
                AuthorizeToken = authenticatedUser.AuthorizeToken.ToString(),
                UserId = authenticatedUser.UserId,
                IdfaEnabled = false,
                SkipLoginNews = true
            };

            return SendResponse(response);
        }
        catch (Exception)
        {
            return SendResponse(new ErrorResponse(errorCode: 407), jsonStatusCode: 600);
        }
    }
}