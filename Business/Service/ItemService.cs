using Data.Repository.Interfaces;
using Models;

namespace Service;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _itemRepository.GetAllItemsAsync();
    }

    public async Task<Item> GetItemByIdAsync(Guid id)
    {
        return await _itemRepository.GetItemByIdAsync(id);
    }
    

    public async Task AddItemAsync(Item item)
    {
        // Perform any business logic or validation before adding
        await _itemRepository.AddItemAsync(item);
    }

    public async Task UpdateItemAsync(Item item)
    {
        // Perform any business logic or validation before updating
        await _itemRepository.UpdateItemAsync(item);
    }

    public async Task DeleteItemAsync(Guid id)
    {
        // Perform any business logic or validation before deleting
        await _itemRepository.DeleteItemAsync(id);
    }
}