using Models;

namespace Data.Repository.Interfaces;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> GetAllAsync();
    Task<Store> GetByIdAsync(Guid id);
    Task AddAsync(Store store);
    Task UpdateAsync(Store store);
    Task DeleteAsync(Guid id);
}