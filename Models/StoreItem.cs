namespace Models;

public class StoreItem
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public Guid ItemId { get; set; }
    public Item Item { get; set; }
}