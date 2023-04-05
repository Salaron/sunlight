using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Live;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/live")]
public class LiveController : LlsifController
{
    [HttpPost("liveStatus")]
    [Produces(typeof(ServerResponse<LiveStatusResponse>))]
    public IActionResult LiveStatus([FromBody] ClientRequest requestData)
    {
        var response = new LiveStatusResponse
        {
            NormalLiveStatusList = new List<object>(),
            SpecialLiveStatusList = new List<object>(),
            MarathonLiveStatusList = new List<object>(),
            TrainingLiveStatusList = new List<object>(),
            FreeLiveStatusList = new List<object>(),
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
            EventList = new List<object>(),
            LiveList = new List<object>(),
            LimitedBonusList = new List<object>(),
            RandomLiveList = new List<object>(),
            FreeLiveList = new List<object>(),
            TrainingLiveList = new List<object>(),
        };

        return SendResponse(response);
    }
}