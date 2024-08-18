namespace Server.Common.Items;

public class ItemDescription<TItemParams>
{
    public AddType AddType { get; set; }
    public int ItemId { get; set; }
    public int ItemCategoryId { get; set; }
    public int Amount { get; set; }
    public TItemParams Parameters { get; set; }

    public ItemDescription(AddType addType, int itemId)
    {
        AddType = addType;
        ItemId = itemId;
    }

    public ItemDescription(AddType addType, int itemId, int amount) : this(addType, itemId)
    {
        Amount = amount;
    }

    public ItemDescription(AddType addType, int itemId, int amount, TItemParams parameters) : this(addType, itemId,
        amount)
    {
        Parameters = parameters;
    }
}