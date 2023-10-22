namespace SunLight.Dtos.Response;

[Serializable]
public class UserInfoStripped
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}