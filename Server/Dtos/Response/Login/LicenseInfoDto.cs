namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LicenseInfoDto
{
    public List<object> LicenseList { get; set; }
    public List<object> LicensedInfo { get; set; }
    public List<object> ExpiredInfo { get; set; }
}