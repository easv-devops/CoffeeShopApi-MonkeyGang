using Models;

namespace Data.Repository.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(Guid id);
    Task<Guid> AddItemAsync(Item item);
    Task UpdateItemAsync(Item item);
    Task DeleteItemAsync(Guid id);
}