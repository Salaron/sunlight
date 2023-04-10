namespace SunLight.Dtos.Response.Class;

[Serializable]
public class ClassSystemResponse
{
    public record ClassRankInfo
    {
        public int BeforeClassRankId { get; set; }
        public int AfterClassRankId { get; set; }
        public DateTime RankUpDate { get; set; }
    }

    public ClassRankInfo RankInfo { get; set; }
    public bool CompleteFlag { get; set; }
    public bool IsOpened { get; set; }
    public bool IsVisible { get; set; }
}