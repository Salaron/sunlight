namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LoginUnitListResponse
{
    public IEnumerable<LoginUnitListMemberCategory> MemberCategoryList { get; set; }
}