namespace SunLight.Dtos.Response.User;

[Serializable]
public class UserInfoStripped
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}