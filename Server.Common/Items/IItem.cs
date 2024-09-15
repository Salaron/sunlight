using Server.Database.Enums;

namespace Server.Common.Items;

public interface IItem
{
    public AddType AddType { get; }
}
