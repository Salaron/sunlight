using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Game.Item;

[PrimaryKey(nameof(LiveNotesIconId))]
public class LiveNotesIconM
{
    public int LiveNotesIconId { get; set; }
}