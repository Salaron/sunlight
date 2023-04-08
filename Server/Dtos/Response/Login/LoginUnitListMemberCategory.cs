namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LoginUnitListMemberCategory
{
    public int MemberCategory { get; set; }
    public IEnumerable<LoginUnitListInitialSet> UnitInitialSet { get; set; }
}