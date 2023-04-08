namespace SunLight.Dtos.Response.Award;

[Serializable]
public class AwardInfoResponse
{
    public IEnumerable<AwardInfo> AwardInfo { get; set; }
}