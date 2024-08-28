using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Items;

public record SocialPointItem(int Amount) : IItem
{
    public AddType AddType => AddType.SocialPoint;
}

public record SocialPointCount(int Total);

internal class SocialPointHandler(ServerContext serverContext) : AddTypeHandler<SocialPointItem, SocialPointCount>
{
    public override AddType AddType => AddType.SocialPoint;

    public override Task<SocialPointCount> AddAsync(int userId, SocialPointItem item)
    {
        if (item.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    public override Task<SocialPointCount> SubtractAsync(int userId, SocialPointItem item)
    {
        if (item.Amount > 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    private async Task<SocialPointCount> ModifyAsync(int userId, SocialPointItem item)
    {
        var user = await serverContext.Users.FindAsync(userId);
        user.SocialPoint += item.Amount;

        serverContext.Update(user);
        await serverContext.SaveChangesAsync();

        return new SocialPointCount(user.GameCoin);
    }
}