using Data;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

public class BrandRepository : IBrandRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public BrandRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        return await _dbContext.Brands.ToListAsync();
    }

    public async Task<Brand> GetByIdAsync(Guid id)
    {
        return await _dbContext.Brands.FindAsync(id);
    }

    public async Task AddAsync(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Brand brand)
    {
        _dbContext.Entry(brand).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var brand = await _dbContext.Brands.FindAsync(id);
        if (brand != null)
        {
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Brand> GetByNameAsync(string name)
    {
        return await _dbContext.Brands.FirstOrDefaultAsync(b => b.Name == name);
    }
}