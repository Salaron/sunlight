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
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public LoginController(ILoginService loginService, IMapper mapper, IConfiguration configuration)
    {
        _loginService = loginService;
        _mapper = mapper;
        _configuration = configuration;
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
            LicenseInfo = new LicenseInfoDto
            {
                ExpiredInfo = Enumerable.Empty<object>(),
                LicensedInfo = Enumerable.Empty<object>(),
                LicenseList = Enumerable.Empty<object>()
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
        var museInitialSet = new List<LoginUnitListInitialSet>();
        var aqoursInitialSet = new List<LoginUnitListInitialSet>();

        var museCenterUnits = _configuration.GetSection("Unit:MuseCenterUnitIds").Get<int[]>();
        var aqoursCenterUnits = _configuration.GetSection("Unit:AqoursCenterUnitIds").Get<int[]>();

        for (var i = 0; i < museCenterUnits.Length; i++)
        {
            var museSet = new LoginUnitListInitialSet
            {
                UnitInitialSetId = museCenterUnits[i],
                CenterUnitId = museCenterUnits[i],
                UnitList = GenerateUnitList(museCenterUnits[i])
            };

            var aqoursSet = new LoginUnitListInitialSet
            {
                UnitInitialSetId = aqoursCenterUnits[i],
                CenterUnitId = aqoursCenterUnits[i],
                UnitList = GenerateUnitList(aqoursCenterUnits[i])
            };

            museInitialSet.Add(museSet);
            aqoursInitialSet.Add(aqoursSet);
        }


        var response = new LoginUnitListResponse
        {
            MemberCategoryList = new List<LoginUnitListMemberCategory>
            {
                new()
                {
                    MemberCategory = 1,
                    UnitInitialSet = museInitialSet
                },
                new()
                {
                    MemberCategory = 2,
                    UnitInitialSet = aqoursInitialSet
                }
            }
        };

        return SendResponse(response);
    }

    private IEnumerable<LoginUnitListUnitInfo> GenerateUnitList(int centerUnitId)
    {
        var baseData = new List<int>
        {
            1391,
            1529,
            1527,
            1487,
            centerUnitId,
            1486,
            1488,
            1528,
            1390
        };

        return baseData.Select(b => new LoginUnitListUnitInfo
        {
            UnitId = b,
            IsRankMax = false
        });
    }
}