using Models;

namespace Data.Repository.Interfaces;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand> GetByIdAsync(Guid id);
    Task AddAsync(Brand brand);
    Task UpdateAsync(Brand brand);
    Task DeleteAsync(Guid id);

    // ekstra metoder
    Task<Brand> GetByNameAsync(string name);
}
