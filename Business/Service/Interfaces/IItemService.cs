using Models;

namespace Service;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(Guid id);
    Task<IEnumerable<Item>> GetItemsByStoreIdAsync(Guid storeId);
    Task AddItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);
}