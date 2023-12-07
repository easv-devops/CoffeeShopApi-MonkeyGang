using Models;

namespace Data.Repository.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(Guid id);
    Task<IEnumerable<Item>> GetItemsByStoreIdAsync(Guid storeId);
    Task AddItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);
}