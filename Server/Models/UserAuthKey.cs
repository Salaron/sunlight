namespace SunLight.Models;

public class UserAuthKey
{
    public Guid AuthorizeToken { get; set; }
    public string SessionKey { get; set; }
    public string ServerKey { get; set; }
}