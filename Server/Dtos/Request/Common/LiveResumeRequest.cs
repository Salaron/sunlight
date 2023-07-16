namespace SunLight.Dtos.Request.Common;

[Serializable]
public class LiveResumeRequest : ClientRequest
{
    public bool Cancel { get; init; }
}