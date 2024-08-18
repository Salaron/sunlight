using Server.Common;

namespace Server.Endpoints.Main.Live;

internal record EventSchedule;

internal record LiveSchedule(
    int LiveDifficultyId,
    DateTime StartDate,
    DateTime EndDate,
    bool IsRandom);

internal record RandomLiveSchedule(int AttributeId, DateTime StartDate, DateTime EndDate);

internal record LiveScheduleResponse(
    List<EventSchedule> EventList,
    List<LiveSchedule> LiveList,
    List<object> LimitedBonusList,
    List<object> LimitedBonusCommonList,
    List<RandomLiveSchedule> RandomLiveList,
    List<object> FreeLiveList,
    List<object> TrainingLiveList);

[Endpoint("live/schedule", usedInApi: true)]
internal class LiveScheduleEndpoint : Action<EmptyObject, LiveScheduleResponse>
{
    public override Task<LiveScheduleResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new LiveScheduleResponse([], [], [], [], [], [], []));
    }
}