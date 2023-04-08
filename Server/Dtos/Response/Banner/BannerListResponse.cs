namespace SunLight.Dtos.Response.Banner;

[Serializable]
public class BannerListResponse
{
    public DateTime TimeLimit { get; set; }
    public IEnumerable<object> BannerList { get; set; }
}