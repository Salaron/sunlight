using Server.Database.Server;

namespace Server.Common.Items;

public class LovecaItem(int amount, bool isPaid = false) : IItem
{
    public AddType AddType => AddType.Loveca;
    public int Amount => amount;
    public bool IsPaid => isPaid;
}

public record LovecaCount(int Total, int Free, int Paid);

internal class LovecaHandler(ServerContext serverContext) : AddTypeHandler<LovecaItem, LovecaCount>
{
    public override AddType AddType => AddType.Loveca;

    public override Task<LovecaCount> AddAsync(int userId, LovecaItem item)
    {
        if (item.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    public override Task<LovecaCount> SubtractAsync(int userId, LovecaItem item)
    {
        if (item.Amount > 0)
            throw new ArgumentOutOfRangeException(nameof(item.Amount));

        return ModifyAsync(userId, item);
    }

    private async Task<LovecaCount> ModifyAsync(int userId, LovecaItem item)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (item.IsPaid)
            user.PaidSnsCoin += item.Amount;
        else
            user.FreeSnsCoin += item.Amount;

        serverContext.Update(user);
        await serverContext.SaveChangesAsync();

        return new LovecaCount(user.PaidSnsCoin + user.FreeSnsCoin, user.FreeSnsCoin, user.PaidSnsCoin);
    }
}