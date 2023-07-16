namespace SunLight.Dtos.Response.Login;

public enum LicenseType
{
    Lbonus = 1,
    Buff = 2,
    Premium = 3,
    Live = 4
}

[Serializable]
public class LicenseInfoDto
{
    public record LicenseInfo
    {
        public int LicenseId { get; set; }
        public LicenseType LicenseType { get; set; }
    }

    public record LicenseUserStatus
    {
        public DateTime EndDate { get; set; }
    }

    public record ActivatedLicenseInfo
    {
        public int LicenseId { get; set; }
        public LicenseType LicenseType { get; set; }
        public LicenseUserStatus UserStatus { get; set; }
    }

    public IEnumerable<LicenseInfo> LicenseList { get; set; }
    public IEnumerable<ActivatedLicenseInfo> LicensedInfo { get; set; }
    public IEnumerable<object> ExpiredInfo { get; set; }
}