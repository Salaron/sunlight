using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Database.Server;
using SunLight.Dtos.Request;
using SunLight.Dtos.Request.Live;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Live;
using SunLight.Dtos.Response.Unit;
using SunLight.Dtos.Response.User;
using SunLight.LiveShow;
using SunLight.Services;
using SunLight.Services.Live;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/live")]
public class LiveController : LlsifController
{
    private readonly ILiveStatusService _liveStatusService;
    private readonly ILiveShowStarter _liveShowStarter;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public LiveController(ILiveStatusService liveStatusService, ILiveShowStarter liveShowStarter,
        IUserService userService, IMapper mapper)
    {
        _liveStatusService = liveStatusService;
        _liveShowStarter = liveShowStarter;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("liveStatus")]
    [Produces(typeof(ServerResponse<LiveStatusResponse>))]
    public async Task<IActionResult> LiveStatus([FromBody] ClientRequest requestData)
    {
        var normalLiveStatus = await _liveStatusService.GetNormalLiveStatusAsync(UserId);
        var specialLiveStatus = await _liveStatusService.GetSpecialLiveStatusAsync(UserId);

        var response = new LiveStatusResponse
        {
            NormalLiveStatusList =
                _mapper.Map<IEnumerable<LiveStatus>, IEnumerable<LiveStatusResponse.LiveStatusItem>>(normalLiveStatus),
            SpecialLiveStatusList =
                _mapper.Map<IEnumerable<LiveStatus>, IEnumerable<LiveStatusResponse.LiveStatusItem>>(specialLiveStatus),
            MarathonLiveStatusList = Enumerable.Empty<object>(),
            TrainingLiveStatusList = Enumerable.Empty<object>(),
            FreeLiveStatusList = Enumerable.Empty<object>(),
            CanResumeLive = true
        };

        return SendResponse(response);
    }

    [HttpPost("schedule")]
    [Produces(typeof(ServerResponse<LiveScheduleResponse>))]
    public IActionResult Schedule([FromBody] ClientRequest requestData)
    {
        var response = new LiveScheduleResponse
        {
            EventList = Enumerable.Empty<object>(),
            LiveList = Enumerable.Empty<object>(),
            LimitedBonusList = Enumerable.Empty<object>(),
            LimitedBonusCommonList = Enumerable.Empty<object>(),
            RandomLiveList = Enumerable.Empty<object>(),
            FreeLiveList = Enumerable.Empty<object>(),
            TrainingLiveList = Enumerable.Empty<object>(),
        };

        return SendResponse(response);
    }

    [HttpPost("partyList")]
    [Produces(typeof(ServerResponse<LivePartyListResponse>))]
    public async Task<IActionResult> PartyList([FromBody] LivePartyListRequest requestData)
    {
        var userInfo = await _userService.GetUserInfoAsync(UserId);

        var partyList = new List<LivePartyListResponse.PartyListItem>
        {
            new()
            {
                UserInfo = _mapper.Map<User, UserInfoStripped>(userInfo),
                CenterUnitInfo = _mapper.Map<UnitOwning, UnitInfoStripped>(userInfo.PartnerUnit),
                SettingAwardId = userInfo.SettingAwardId,
                AvailableSocialPoint = 0,
                FriendStatus = 1
            }
        };

        var response = new LivePartyListResponse
        {
            PartyList = partyList
        };

        return SendResponse(response);
    }

    [HttpPost("play")]
    [Produces(typeof(ServerResponse<LivePlayResponse>))]
    public async Task<IActionResult> Play([FromBody] LivePlayRequest requestData)
    {
        var liveDifficultyId = int.Parse(requestData.LiveDifficultyId);
        var liveStartInfo =
            await _liveShowStarter.StartLiveShowAsync(UserId, new[] { liveDifficultyId }, requestData.UnitDeckId);

        var response = new LivePlayResponse
        {
            RankInfo = liveStartInfo.RankInfo,
            LiveList = liveStartInfo.LiveList,
            EnergyFullTime = DateTime.UtcNow.ToServerTime(),
            AvailableLiveResume = true,
            IsMarathonEvent = false,
            NoSkill = false,
            CanActivateEffect = true
        };

        return SendResponse(response);
    }
}