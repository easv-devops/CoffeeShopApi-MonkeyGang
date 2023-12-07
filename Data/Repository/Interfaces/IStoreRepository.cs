using Models;

namespace Data.Repository.Interfaces;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> GetAllAsync();
    Task<Store> GetByIdAsync(Guid id);
    Task<IEnumerable<Store>> GetStoresByBrandIdAsync(Guid brandId); // New method
    Task AddAsync(Store store);
    Task UpdateAsync(Store store);
    Task DeleteAsync(Guid id);
}