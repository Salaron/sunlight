namespace SunLight.Dtos.Response.Museum;

[Serializable]
public class MuseumInfoResponse
{
    public MuseumInfoStats MuseumInfo { get; set; }
    public IEnumerable<int> ContentsIdList { get; set; }
}