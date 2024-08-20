using Server.Database.Enums;

namespace Server.Common.Items;

public interface IAddTypeHandler
{
    AddType AddType { get; }
    Task<object> AddAsync(int userId, IItem item);
    Task<object> SubtractAsync(int userId, IItem item);
}

public interface IAddTypeHandler<in TItem, TResult> : IAddTypeHandler where TItem : IItem
{
    Task<TResult> AddAsync(int userId, TItem item);
    Task<TResult> SubtractAsync(int userId, TItem item);
}

public abstract class AddTypeHandler<TItem, TResult> : IAddTypeHandler<TItem, TResult> where TItem : IItem
{
    public abstract AddType AddType { get; }
    public abstract Task<TResult> AddAsync(int userId, TItem item);
    public abstract Task<TResult> SubtractAsync(int userId, TItem item);
    
    public async Task<object> AddAsync(int userId, IItem item)
    {
        return Task.FromResult<object>(await AddAsync(userId, (TItem)item));
    }

    public async Task<object> SubtractAsync(int userId, IItem item)
    {
        return Task.FromResult<object>(await AddAsync(userId, (TItem)item));
    }
}