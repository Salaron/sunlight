using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Item;

[PrimaryKey(nameof(LiveNotesIconId))]
public class GameLiveNotesIconItem
{
    public int LiveNotesIconId { get; set; }
}