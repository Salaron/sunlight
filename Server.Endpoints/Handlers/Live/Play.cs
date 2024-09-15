using System.ComponentModel.DataAnnotations;
using Server.Common;
using Server.Common.Live;
using Server.Common.Users;

namespace Server.Endpoints.Handlers.Live;

internal record LivePlayRequest(
    int PartyUserId,
    bool IsTraining,
    int UnitDeckId,
    string LiveDifficultyId,
    [Range(1, 4)]
    int LpFactor);

internal record LivePlayResponse
{
    public IEnumerable<LiveRankInfo> RankInfo { get; set; }
    public DateTime EnergyFullTime { get; set; }
    public IEnumerable<LiveInfoWithDeck> LiveList { get; set; }
    public bool AvailableLiveResume { get; set; }
    public bool IsMarathonEvent { get; set; }
    public bool NoSkill { get; set; } // skill issue
    public bool CanActivateEffect { get; set; }
}

[Endpoint("live/play")]
internal class LivePlayEndpoint(IActionContext context, ILiveShowStarter liveShowStarter, IUserService userService)
    : Action<LivePlayRequest, LivePlayResponse>
{
    public override async Task<LivePlayResponse> ExecuteAsync(LivePlayRequest requestBody)
    {
        var liveDifficultyId = int.Parse(requestBody.LiveDifficultyId);

        var user = await userService.GetAsync(context.UserId);
        var start = await liveShowStarter.StartLiveShowAsync(context.UserId, [liveDifficultyId],
            requestBody.UnitDeckId);

        var response = new LivePlayResponse
        {
            RankInfo = start.ScoreRank,
            LiveList = start.LiveList,
            EnergyFullTime = user.EnergyFullTime,
            AvailableLiveResume = true,
            IsMarathonEvent = false,
            NoSkill = false,
            CanActivateEffect = true
        };

        return response;
    }
}