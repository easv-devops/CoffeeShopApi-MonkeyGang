using Data.Repository.Interfaces;
using Models;

namespace Service;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IStoreItemRepository _storeItemRepository;
    public StoreService(IStoreRepository storeRepository, IStoreItemRepository storeItemRepository)
    {
        _storeRepository = storeRepository;
        _storeItemRepository = storeItemRepository;
    }

    public async Task<IEnumerable<Store>> GetAllStoresAsync()
    {
        return await _storeRepository.GetAllAsync();
    }

    public async Task<Store> GetStoreByIdAsync(Guid id)
    {
        return await _storeRepository.GetByIdAsync(id);
    }


    public async Task AddStoreAsync(Store store)
    {
        // Perform any business logic or validation before adding
        await _storeRepository.AddAsync(store);
    }

    public async Task UpdateStoreAsync(Store store)
    {
        // Perform any business logic or validation before updating
        await _storeRepository.UpdateAsync(store);
    }

    public async Task DeleteStoreAsync(Guid id)
    {
        // Perform any business logic or validation before deleting
        await _storeRepository.DeleteAsync(id);
    }
    
 

    public IEnumerable<Item> GetItemsByStoreId(Guid storeId)
    {
        return _storeItemRepository.GetItemsByStoreId(storeId);
    }
    
}