namespace SunLight.Dtos.Response;

[Serializable]
public class UserInfoResponse
{
    public UserInfoDto User { get; set; }
    public UserBirthDto Birth { get; set; }
    public bool AdStatus { get; set; }
}