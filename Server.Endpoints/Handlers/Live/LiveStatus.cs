using Server.Common;

namespace Server.Endpoints.Main.Live;

internal record LiveStatus(
    int LiveDifficultyId,
    int Status,
    int HiScore,
    int HiComboCount,
    int ClearCnt,
    List<int> AchievedGoalIdList);

internal record LiveStatusResponse(
    List<LiveStatus> NormalLiveStatusList,
    List<LiveStatus> SpecialLiveStatusList,
    List<LiveStatus> MarathonLiveStatusList,
    List<LiveStatus> TrainingLiveStatusList,
    List<LiveStatus> FreeLiveStatusList,
    bool CanResumeLive);

[Endpoint("live/liveStatus", usedInApi: true)]
internal class LiveStatusEndpoint : Action<EmptyObject, LiveStatusResponse>
{
    public override Task<LiveStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new LiveStatusResponse([], [], [], [], [], true));
    }
}