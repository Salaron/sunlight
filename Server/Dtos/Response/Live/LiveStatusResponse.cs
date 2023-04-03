namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LiveStatusResponse : BaseResponse
{
    public List<object> NormalLiveStatusList { get; set; }
    public List<object> SpecialLiveStatusList { get; set; }
    public List<object> MarathonLiveStatusList { get; set; }
    public List<object> TrainingLiveStatusList { get; set; }
    public List<object> FreeLiveStatusList { get; set; }
    public bool CanResumeLive { get; set; }
}