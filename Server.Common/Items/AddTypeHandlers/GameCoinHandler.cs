using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public record GameCoinItem(int Amount) : IItem
{
    public AddType AddType => AddType.GameCoin;
}

public record GameCoinCount(int Total);

internal class GameCoinHandler(ServerContext serverContext) : AddTypeHandler<GameCoinItem, GameCoinCount>
{
    public override AddType AddType => AddType.GameCoin;

    public override Task<GameCoinCount> AddAsync(int userId, GameCoinItem item)
    {
        if (item.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    public override Task<GameCoinCount> SubtractAsync(int userId, GameCoinItem item)
    {
        if (item.Amount > 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    private async Task<GameCoinCount> ModifyAsync(int userId, GameCoinItem item)
    {
        var user = await serverContext.Users.FindAsync(userId);
        user.GameCoin += item.Amount;

        serverContext.Update(user);
        await serverContext.SaveChangesAsync();

        return new GameCoinCount(user.GameCoin);
    }
}