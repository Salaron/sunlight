using Server.Database.Enums;

namespace Server.Common.Items;

public class ItemManager
{
    private readonly Dictionary<AddType, IAddTypeHandler> _handlers;

    public ItemManager(IEnumerable<IAddTypeHandler> handlers)
    {
        _handlers = handlers.ToDictionary(x => x.AddType, x => x);
    }

    public Task AddAsync(int userId, IItem item)
    {
        if (!_handlers.TryGetValue(item.AddType, out var handler))
            throw new InvalidOperationException();

        return handler.AddAsync(userId, item);
    }
    
    public Task<TResult> AddAsync<TItem, TResult>(int userId, TItem item) where TItem : IItem
    {
        _handlers.TryGetValue(item.AddType, out var handler);
        if (handler is not IAddTypeHandler<TItem, TResult> typedHandler)
            throw new InvalidOperationException();

        var result = typedHandler.AddAsync(userId, item);

        return result;
    }
}