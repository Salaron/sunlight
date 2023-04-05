namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LiveScheduleResponse
{
    public IEnumerable<object> EventList { get; set; }
    public IEnumerable<object> LiveList { get; set; }
    public IEnumerable<object> LimitedBonusList { get; set; }
    public IEnumerable<object> RandomLiveList { get; set; }
    public IEnumerable<object> FreeLiveList { get; set; }
    public IEnumerable<object> TrainingLiveList { get; set; }
}