namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LiveStatusResponse
{
    public IEnumerable<object> NormalLiveStatusList { get; set; }
    public IEnumerable<object> SpecialLiveStatusList { get; set; }
    public IEnumerable<object> MarathonLiveStatusList { get; set; }
    public IEnumerable<object> TrainingLiveStatusList { get; set; }
    public IEnumerable<object> FreeLiveStatusList { get; set; }
    public bool CanResumeLive { get; set; }
}