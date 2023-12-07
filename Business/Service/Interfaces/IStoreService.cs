using Models;

namespace Service;

public interface IStoreService
{
    Task<IEnumerable<Store>> GetAllStoresAsync();
    Task<Store> GetStoreByIdAsync(Guid id);
    Task<IEnumerable<Store>> GetStoresByBrandIdAsync(Guid brandId);
    Task AddStoreAsync(Store store);
    Task UpdateStoreAsync(Store store);
    Task DeleteStoreAsync(Guid id);
}