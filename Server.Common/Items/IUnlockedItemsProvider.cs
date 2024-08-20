using Server.Database.Enums;

namespace Server.Common.Items;

public interface IUnlockedItemsProvider
{
    Task<bool> IsItemUnlockedAsync(int userId, AddType addType, int itemId);
    Task<IReadOnlyList<UnlockedItem>> GetUnlockedAsync(int userId, AddType addType);
}