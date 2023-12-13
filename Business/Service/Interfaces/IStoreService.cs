using Models;

namespace Service;

public interface IStoreService
{
    Task<IEnumerable<Store>> GetAllStoresAsync();
    Task<Store> GetStoreByIdAsync(Guid id);
    Task AddStoreAsync(Store store);
    Task UpdateStoreAsync(Store store);
    Task DeleteStoreAsync(Guid id);
    
    IEnumerable<Item> GetItemsByStoreId(Guid storeId);
    
}