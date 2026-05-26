using Server.Common;

namespace Server.Endpoints.Handlers.Live;

internal record LiveRewardRequest(
    int LiveDifficultyId,
    int MissCnt,
    int BadCnt,
    int GoodCnt,
    int PerfectCnt,
    int MaxCombo,
    int LoveCnt,
    int ScoreCool,
    int ScoreCute,
    int ScoreSmile,
    int RemainHp,
    int EventPoint,
    bool IsTraining,
    object PreciseScoreLog);


[Endpoint("live/reward")]
internal class RewardEndpoint(IActionContext context) : Action<LiveRewardRequest, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(LiveRewardRequest requestBody)
    {
        throw new ActionException(3411);
    }
}