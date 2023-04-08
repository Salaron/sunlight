namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LoginUnitListInitialSet
{
    public int UnitInitialSetId { get; set; }
    public IEnumerable<LoginUnitListUnitInfo> UnitList { get; set; }
    public int CenterUnitId { get; set; }
}