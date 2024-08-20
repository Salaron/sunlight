using Server.Common.Users;
using Server.Database.Enums;

namespace Server.Common.Items;

public class PlayerExpItem(int amount) : IItem
{
    public AddType AddType => AddType.PlayerExp;
    public int Amount => amount;
}

internal class PlayerExpHandler(IUserService userService) : AddTypeHandler<PlayerExpItem, IReadOnlyList<UserNextLevelInfo>>
{
    public override AddType AddType => AddType.PlayerExp;

    public override Task<IReadOnlyList<UserNextLevelInfo>> AddAsync(int userId, PlayerExpItem item)
    {
        if (item.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return userService.AddExp(userId, item.Amount);
    }

    public override Task<IReadOnlyList<UserNextLevelInfo>> SubtractAsync(int userId, PlayerExpItem item)
    {
        throw new InvalidOperationException();
    }
}