namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LoginResponse : BaseResponse
{
    public uint UserId { get; set; }
    public string AuthorizeToken { get; set; }
    public bool IdfaEnabled { get; set; }
    public bool SkipLoginNews { get; set; }
}