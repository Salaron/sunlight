using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Item;

[PrimaryKey(nameof(LiveSeId))]
public class LiveSeM
{
    public int LiveSeId { get; set; }
}