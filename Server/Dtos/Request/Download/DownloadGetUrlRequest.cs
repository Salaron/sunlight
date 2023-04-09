namespace SunLight.Dtos.Request.Download;

[Serializable]
public class DownloadGetUrlRequest : ClientRequest
{
    public string Os { get; init; }
    public IEnumerable<string> PathList { get; init; }
}