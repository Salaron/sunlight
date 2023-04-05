namespace SunLight.Dtos.Response.User;

[Serializable]
public class UserInfoResponse
{
    public UserInfoDto User { get; set; }
    public UserBirthDto Birth { get; set; }
    public bool AdStatus { get; set; }
}