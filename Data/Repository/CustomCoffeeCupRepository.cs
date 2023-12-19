using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class CustomCoffeeCupRepository : ICustomCoffeeCupRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public CustomCoffeeCupRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomCoffeeCup> GetCustomCoffeeCupByIdAsync(Guid id)
    {
        return await _dbContext.CustomCoffeeCups
            .Include(c => c.User) 
            .FirstOrDefaultAsync(c => c.ItemId == id);
    }

    public async Task<IEnumerable<CustomCoffeeCup>> GetAllCustomCoffeeCupsAsync()
    {
        return await _dbContext.CustomCoffeeCups
            .Include(c => c.User) 
            .ToListAsync();
    }

    public async Task<Guid> CreateCustomCoffeeCupAsync(CustomCoffeeCup customCoffeeCup)
    {
        _dbContext.CustomCoffeeCups.Add(customCoffeeCup);
        await _dbContext.SaveChangesAsync();

        return customCoffeeCup.ItemId;
    }

    public async Task UpdateCustomCoffeeCupAsync(CustomCoffeeCup customCoffeeCup)
    {
        _dbContext.Entry(customCoffeeCup).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteCustomCoffeeCupAsync(Guid id)
    {
        var customCoffeeCup = await _dbContext.CustomCoffeeCups.FindAsync(id);

        if (customCoffeeCup != null)
        {
            _dbContext.CustomCoffeeCups.Remove(customCoffeeCup);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}