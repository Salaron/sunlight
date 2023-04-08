namespace SunLight.Dtos.Response.Notice;

[Serializable]
public class NoticeMarqueeResponse
{
    public int ItemCount { get; set; }
    public IEnumerable<object> MarqueeList { get; set; }
}