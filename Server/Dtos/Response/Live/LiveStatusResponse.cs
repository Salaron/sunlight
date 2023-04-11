namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LiveStatusResponse
{
    public class LiveStatusItem
    {
        public int LiveDifficultyId { get; set; }
        public int Status { get; set; }
        public int HiScore { get; set; }
        public int HiComboCount { get; set; }
        public int ClearCnt { get; set; }
        public List<int> AchievedGoalIdList { get; set; }
    }

    public IEnumerable<LiveStatusItem> NormalLiveStatusList { get; set; }
    public IEnumerable<LiveStatusItem> SpecialLiveStatusList { get; set; }
    public IEnumerable<object> MarathonLiveStatusList { get; set; }
    public IEnumerable<object> TrainingLiveStatusList { get; set; }
    public IEnumerable<object> FreeLiveStatusList { get; set; }
    public bool CanResumeLive { get; set; }
}