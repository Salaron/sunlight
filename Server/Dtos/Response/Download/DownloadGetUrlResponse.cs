namespace SunLight.Dtos.Response.Download;

[Serializable]
public class DownloadGetUrlResponse
{
    public IEnumerable<string> UrlList { get; set; }
}