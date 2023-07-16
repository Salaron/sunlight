using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Database.Server;
using SunLight.Dtos.Request;
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
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public LoginController(ILoginService loginService, IUserService userService, IMapper mapper)
    {
        _loginService = loginService;
        _userService = userService;
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
            var registeredUser =
                await _loginService.RegisterAsync(requestData.LoginKey, requestData.LoginPasswd,
                    parsedAuthorizeHeader.Token);

            var response = new LoginResponse
            {
                AuthorizeToken = registeredUser.AuthorizeToken.ToString(),
                UserId = registeredUser.UserId,
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
    [Produces(typeof(ServerResponse<TopInfoResponse>))]
    public IActionResult TopInfo([FromBody] ClientRequest requestData)
    {
        var licenseUserStatus = new LicenseInfoDto.LicenseUserStatus
        {
            EndDate = DateTime.MaxValue
        };
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
            ServerDatetime = DateTimeUtils.GetServerTime(),
            LicenseInfo = new LicenseInfoDto
            {
                LicenseList = new List<LicenseInfoDto.LicenseInfo>
                {
                    new() { LicenseId = 1, LicenseType = LicenseType.Lbonus },
                    new() { LicenseId = 2, LicenseType = LicenseType.Buff },
                    new() { LicenseId = 3, LicenseType = LicenseType.Premium },
                    new() { LicenseId = 4, LicenseType = LicenseType.Live },
                },
                LicensedInfo = new List<LicenseInfoDto.ActivatedLicenseInfo>
                {
                    new() { LicenseId = 1, LicenseType = LicenseType.Lbonus, UserStatus = licenseUserStatus },
                    new() { LicenseId = 2, LicenseType = LicenseType.Buff, UserStatus = licenseUserStatus },
                    new() { LicenseId = 3, LicenseType = LicenseType.Premium, UserStatus = licenseUserStatus },
                    new() { LicenseId = 4, LicenseType = LicenseType.Live, UserStatus = licenseUserStatus },
                },
                ExpiredInfo = Enumerable.Empty<object>(),
            },
            UsingBuffInfo = Enumerable.Empty<object>(),
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
    [Produces(typeof(ServerResponse<TopInfoOnceResponse>))]
    public IActionResult TopInfoOnceAsync([FromBody] ClientRequest requestData)
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

    [HttpPost("unitList")]
    [Produces(typeof(ServerResponse<LoginUnitListResponse>))]
    public IActionResult UnitList([FromBody] ClientRequest requestData)
    {
        var response = new LoginUnitListResponse
        {
            MemberCategoryList = new List<LoginUnitListMemberCategory>
            {
                _loginService.GetInitialUnitList(memberCategory: 1),
                _loginService.GetInitialUnitList(memberCategory: 2)
            }
        };

        return SendResponse(response);
    }

    [HttpPost("unitSelect")]
    [Produces(typeof(ServerResponse<LoginUnitSelectResponse>))]
    public async Task<IActionResult> UnitSelect([FromBody] LoginUnitSelectRequest requestData)
    {
        var ids = await _loginService.CreateDefaultDeckAsync(UserId, requestData.UnitInitialSetId);
        var response = new LoginUnitSelectResponse
        {
            UnitId = ids
        };

        await _userService.SetPartnerUnitAsync(UserId, ids[4]);

        return SendResponse(response);
    }
}