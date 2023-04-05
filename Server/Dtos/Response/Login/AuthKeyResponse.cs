namespace SunLight.Dtos.Response.Login;

[Serializable]
public class AuthKeyResponse
{
    public string AuthorizeToken { get; set; }
    public string DummyToken { get; set; }
}