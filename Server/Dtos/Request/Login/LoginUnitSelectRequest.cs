namespace SunLight.Dtos.Request.Login;

[Serializable]
public class LoginUnitSelectRequest : ClientRequest
{
    public int UnitInitialSetId { get; init; }
}