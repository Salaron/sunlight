using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Game.Item;

[PrimaryKey(nameof(LiveSeId))]
public class LiveSeM
{
    public int LiveSeId { get; set; }
}