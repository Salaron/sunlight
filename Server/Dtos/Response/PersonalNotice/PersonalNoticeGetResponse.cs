namespace SunLight.Dtos.Response.PersonalNotice;

[Serializable]
public class PersonalNoticeGetResponse
{
    public bool HasNotice { get; set; }
    public int NoticeId { get; set; }
    public int Type { get; set; }
    public string Title { get; set; }
    public string Contents { get; set; }
}