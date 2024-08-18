namespace Server.Common.Login;

public class AuthKey
{
    public string AuthorizeToken { get; set; }
    public string SessionKey { get; set; }
    public string ServerKey { get; set; }
    public DateTime Expires { get; set; }
}