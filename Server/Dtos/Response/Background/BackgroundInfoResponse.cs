namespace SunLight.Dtos.Response.Background;

[Serializable]
public class BackgroundInfoResponse
{
    public IEnumerable<BackgroundInfo> BackgroundInfo { get; set; }
}