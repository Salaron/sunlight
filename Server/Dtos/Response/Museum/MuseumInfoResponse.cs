namespace SunLight.Dtos.Response.Museum;

[Serializable]
public class MuseumInfoResponse
{
    public record MuseumInfoParams
    {
        public MuseumInfoStats Parameter { get; set; }
        public IEnumerable<int> ContentsIdList { get; set; }
    }

    public MuseumInfoParams MuseumInfo { get; set; }
}