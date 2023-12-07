using Models;

namespace Service;

public interface IBrandService
{
    Task<IEnumerable<Brand>> GetAllBrandsAsync();
    Task<Brand> GetBrandByIdAsync(Guid id);
    Task AddBrandAsync(Brand brand);
    Task UpdateBrandAsync(Brand brand);
    Task DeleteBrandAsync(Guid id);
}