namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LiveScheduleResponse : BaseResponse
{
    public List<object> EventList { get; set; }
    public List<object> LiveList { get; set; }
    public List<object> LimitedBonusList { get; set; }
    public List<object> RandomLiveList { get; set; }
    public List<object> FreeLiveList { get; set; }
    public List<object> TrainingLiveList { get; set; }
}