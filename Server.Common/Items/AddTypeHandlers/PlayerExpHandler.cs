using Server.Common.Users;

namespace Server.Common.Items;

public class PlayerExpItem(int amount) : IItem
{
    public AddType AddType => AddType.PlayerExp;
    public int Amount => amount;
}

public record PlayerExpInfo(int Level, int FromExp);

internal class PlayerExpHandler(IUserService userService) : AddTypeHandler<PlayerExpItem, List<PlayerExpInfo>>
{
    public override AddType AddType => AddType.PlayerExp;

    public override async Task<List<PlayerExpInfo>> AddAsync(int userId, PlayerExpItem item)
    {
        if (item.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        await userService.AddExp(userId, item.Amount);

        return [];
    }

    public override Task<List<PlayerExpInfo>> SubtractAsync(int userId, PlayerExpItem item)
    {
        throw new InvalidOperationException();
    }
}