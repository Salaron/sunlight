using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Item;

[PrimaryKey(nameof(LiveSeId))]
public class GameLiveSeItem
{
    public int LiveSeId { get; set; }
}