namespace Server.Common.Items;

public interface IItemHandler
{
    AddType AddType { get; }

    Task<object> AddAsync(int userId, ItemDescription<object> param);
}

public interface IItemHandler<TParams, TItem> : IItemHandler
{
    Task<TItem> AddAsync(int userId, ItemDescription<TParams> param);
}

public abstract class ItemHandler<TParams, TItem> : IItemHandler<TParams, TItem>
{
    public abstract AddType AddType { get; }
    public abstract Task<TItem> AddAsync(int userId, ItemDescription<TParams> param);

    public Task<object> AddAsync(int userId, ItemDescription<object> param)
    {
        return Task.FromResult<object>(AddAsync(userId, param as ItemDescription<TParams>));
    }
}