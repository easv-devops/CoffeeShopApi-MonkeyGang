using Data.Repository.Interfaces;
using Models;

namespace Service;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
    {
        return await _brandRepository.GetAllAsync();
    }

    public async Task<Brand> GetBrandByIdAsync(Guid id)
    {
        return await _brandRepository.GetByIdAsync(id);
    }

    // husk at lave validation
    
    public async Task AddBrandAsync(Brand brand)
    {
        
        if (string.IsNullOrEmpty(brand.Name))
        {
            throw new ArgumentException("Brand name cannot be null or empty.", nameof(brand));
        }

        // Length constraint for the Name property
        if (brand.Name.Length > 50)
        {
            throw new ArgumentException("Brand name length cannot exceed 50 characters.", nameof(brand));
        }

        // Uniqueness check for the Name property
        var existingBrand = await _brandRepository.GetByNameAsync(brand.Name);
        if (existingBrand != null)
        {
            throw new InvalidOperationException("Brand with the same name already exists.");
        }
        
        
        await _brandRepository.AddAsync(brand);
    }

    public async Task UpdateBrandAsync(Brand brand)
    {
        await _brandRepository.UpdateAsync(brand);
    }

    public async Task DeleteBrandAsync(Guid id)
    {
        await _brandRepository.DeleteAsync(id);
    }
}