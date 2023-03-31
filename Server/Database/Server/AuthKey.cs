using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

[PrimaryKey(nameof(AuthorizeToken))]
public class AuthKey
{
    public Guid AuthorizeToken { get; set; }
    public string SessionKey { get; set; }
    public string ServerKey { get; set; }
    public DateTime CreationTime { get; set; }
}