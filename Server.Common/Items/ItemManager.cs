namespace Server.Common.Items;

public class ItemManager
{
    private readonly Dictionary<AddType, IItemHandler> _handlers;

    public ItemManager(IEnumerable<IItemHandler> handlers)
    {
        _handlers = handlers.ToDictionary(x => x.AddType, x => x);
    }

    public Task<TItem>? AddAsync<TItemParams, TItem>(int userId, ItemDescription<TItemParams> description)
    {
        _handlers.TryGetValue(description.AddType, out var handler);
        if (handler is not IItemHandler<TItemParams, TItem> typedHandler)
            throw new InvalidOperationException();

        var result = typedHandler?.AddAsync(userId, description);

        return result;
    }
}