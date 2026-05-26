using Server.Common;
using Server.Common.Live;
using Server.Database.Enums;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Live;

internal record LiveStatusDto
{
    public int LiveDifficultyId { get; init; }
    public LiveStatus Status { get; init; }
    public int HiScore { get; init; }
    public int HiComboCount { get; init; }
    public int ClearCnt { get; init; }
    public List<int> AchievedGoalIdList { get; init; }
}

internal record LiveStatusResponse(
    IEnumerable<LiveStatusDto> NormalLiveStatusList,
    IEnumerable<LiveStatusDto> SpecialLiveStatusList,
    IEnumerable<LiveStatusDto> MarathonLiveStatusList,
    IEnumerable<LiveStatusDto> TrainingLiveStatusList,
    IEnumerable<LiveStatusDto> FreeLiveStatusList,
    bool CanResumeLive);

[Endpoint("live/liveStatus", usedInApi: true)]
internal class LiveStatusEndpoint(IActionContext context, ILiveStatusProvider liveStatusProvider)
    : Action<EmptyObject, LiveStatusResponse>
{
    public override async Task<LiveStatusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var normalLives = await liveStatusProvider.GetNormalLiveStatusAsync(context.UserId);
        var specialLives = await liveStatusProvider.GetSpecialLiveStatusAsync(context.UserId);

        var response = new LiveStatusResponse(
            NormalLiveStatusList: normalLives.Select(Mappers.Live.LiveStatusInfoToDto),
            SpecialLiveStatusList: specialLives.Select(Mappers.Live.LiveStatusInfoToDto),
            MarathonLiveStatusList: [],
            TrainingLiveStatusList: [],
            FreeLiveStatusList: [],
            CanResumeLive: true);

        return response;
    }
}
