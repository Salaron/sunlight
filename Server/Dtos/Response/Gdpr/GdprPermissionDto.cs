namespace SunLight.Dtos.Response.Gdpr;

[Serializable]
public class GdprPermissionDto
{
    public int Type { get; set; }
    public int Granted { get; set; }
    public string Ex { get; set; }
}