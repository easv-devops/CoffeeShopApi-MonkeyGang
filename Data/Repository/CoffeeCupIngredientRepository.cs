using Data;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

public class CoffeeCupIngredientRepository : ICoffeeCupIngredientRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public CoffeeCupIngredientRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CoffeeCupIngredient> GetByIdAsync(Guid coffeeCupId, Guid ingredientId)
    {
        return await _dbContext.CoffeeCupIngredients.FindAsync(coffeeCupId, ingredientId);
    }

    public async Task<IEnumerable<CoffeeCupIngredient>> GetAllAsync(Guid coffeeCupId)
    {
        return await _dbContext.CoffeeCupIngredients.Where(ci => ci.CoffeeCupId == coffeeCupId).ToListAsync();
    }

    public async Task AddAsync(CoffeeCupIngredient coffeeCupIngredient)
    {
        _dbContext.CoffeeCupIngredients.Add(coffeeCupIngredient);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<CoffeeCupIngredient> coffeeCupIngredients)
    {
        _dbContext.CoffeeCupIngredients.AddRange(coffeeCupIngredients);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(CoffeeCupIngredient coffeeCupIngredient)
    {
        _dbContext.Entry(coffeeCupIngredient).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(CoffeeCupIngredient coffeeCupIngredient)
    {
        _dbContext.CoffeeCupIngredients.Remove(coffeeCupIngredient);
        await _dbContext.SaveChangesAsync();
    }
}