namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LoginUnitSelectResponse
{
    public IEnumerable<int> UnitId { get; set; }
}