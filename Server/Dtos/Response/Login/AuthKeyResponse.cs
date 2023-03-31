namespace SunLight.Dtos.Login;

public class AuthKeyResponse : BaseResponse
{
    public string AuthorizeToken { get; set; }
    public string DummyToken { get; set; }
}
