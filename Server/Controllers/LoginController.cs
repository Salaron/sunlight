using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Database.Server;
using SunLight.Dtos.Request.Login;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Login;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/login")]
public class LoginController : LlsifController
{
    private readonly ILoginService _loginService;
    private readonly IMapper _mapper;

    public LoginController(ILoginService loginService, IMapper mapper)
    {
        _loginService = loginService;
        _mapper = mapper;
    }

    [HttpPost("authKey")]
    [XMessageCodeCheck(performCheck: false)]
    [Produces(typeof(ServerResponse<AuthKeyResponse>))]
    public async Task<IActionResult> AuthKeyAsync([FromBody] AuthKeyRequest requestData)
    {
        var userAuthKey = await _loginService.StartSessionAsync(requestData.DummyToken);

        var response = _mapper.Map<AuthKey, AuthKeyResponse>(userAuthKey);

        return SendResponse(response);
    }

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

    [HttpPost("startUp")]
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

    [HttpPost("topInfo")]
    [BatchApiCall("login", "topInfo")]
    [Produces(typeof(ServerResponse<TopInfoResponse>))]
    public IActionResult TopInfo()
    {
        var response = new TopInfoResponse
        {
            FriendActionCnt = 0,
            FriendGreetCnt = 0,
            FriendVarietyCnt = 0,
            FriendNewCnt = 0,
            FriendsApprovalWaitCnt = 0,
            FriendsRequestCnt = 0,
            IsTodayBirthday = false,
            PresentCnt = 0,
            SecretBoxBadgeFlag = false,
            ServerDatetime = "",
            LicenseInfo = new LicenseInfoDto(),
            UsingBuffInfo = new List<object>(),
            IsKlabIdTaskFlag = false,
            KlabIdTaskCanSync = false,
            HasUnreadAnnounce = false,
            ExchangeBadgeCnt = new List<int>
            {
                0, // seal shop
                0, // point shop
                0 // idk
            },
            AdFlag = false,
            HasAdReward = false
        };

        return SendResponse(response);
    }

    [HttpPost("topInfoOnce")]
    [BatchApiCall("login", "topInfoOnce")]
    [Produces(typeof(ServerResponse<TopInfoOnceResponse>))]
    public IActionResult TopInfoOnceAsync()
    {
        var response = new TopInfoOnceResponse
        {
            NewAchievementCnt = 0,
            UnaccomplishedAchievementCnt = 0,
            LiveDailyRewardExist = false,
            TrainingEnergy = 5,
            TrainingEnergyMax = 5,
            Notification = new NotificationDto(),
            OpenArena = false,
            CostumeStatus = false,
            OpenAccessory = false,
            ArenaSiSkillUniqueCheck = false,
            OpenV98 = true // m_live_custom
        };

        return SendResponse(response);
    }
}