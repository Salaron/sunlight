namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LicenseInfoDto
{
    public IEnumerable<object> LicensedInfo { get; set; }
    public IEnumerable<object> ExpiredInfo { get; set; }
    public IEnumerable<object> LicenseList { get; set; }
}