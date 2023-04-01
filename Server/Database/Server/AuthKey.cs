using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

[PrimaryKey(nameof(AuthorizeToken))]
public class AuthKey
{
    public Guid AuthorizeToken { get; set; }
    public string SessionKey { get; set; }
    public string ServerKey { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? CreationTime { get; set; }
}