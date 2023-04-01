using System.ComponentModel.DataAnnotations.Schema;

namespace SunLight.Database.Server;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint UserId { get; init; }

    public string LoginKey { get; set; }
    public string LoginPasswd { get; set; }

    public Guid AuthorizeToken { get; set; }
    public DateTime LastLogin { get; set; }
}