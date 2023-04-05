namespace SunLight.Dtos.Response.Gdpr;

[Serializable]
public class GdprGetResponse
{
    public bool EnableGdpr { get; set; }
    public bool IsEea { get; set; }
    public bool HasRequested { get; set; }
    public IEnumerable<GdprPermissionDto> Permissions { get; set; }
}