namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LiveScheduleResponse
{
    public record LiveScheduleInfo
    {
        public int LiveDifficultyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRandom { get; set; }
    }

    public IEnumerable<object> EventList { get; set; }
    public IEnumerable<LiveScheduleInfo> LiveList { get; set; }
    public IEnumerable<object> LimitedBonusList { get; set; }
    public IEnumerable<object> LimitedBonusCommonList { get; set; }
    public IEnumerable<object> RandomLiveList { get; set; }
    public IEnumerable<object> FreeLiveList { get; set; }
    public IEnumerable<object> TrainingLiveList { get; set; }
}