namespace SunLight.Dtos.Response.Login;

[Serializable]
public class LoginResponse : BaseResponse
{
    public uint UserId { get; set; }
}