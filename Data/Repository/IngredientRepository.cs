using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class IngredientRepository : IIngredientRepository
{

    private readonly CoffeeShopDbContext _dbContext;

    public IngredientRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Ingredient> GetIngredientByIdAsync(Guid ingredientId)
    {
        //Possible null reference return
        return await _dbContext.Ingredients.FindAsync(ingredientId);
        
    }

    public async Task<List<Ingredient>> GetAllIngredientsAsync()
    {
        return await _dbContext.Ingredients.ToListAsync();
    }
    
    public async Task<Guid> AddIngredientAsync(Ingredient ingredient)
    {
        await _dbContext.Ingredients.AddAsync(ingredient);
        await _dbContext.SaveChangesAsync();
        return ingredient.IngredientId;
    }

    public async Task<bool> UpdateIngredientAsync(Ingredient ingredient)
    {
        _dbContext.Ingredients.Update(ingredient);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteIngredientAsync(Ingredient ingredient)
    {
        _dbContext.Ingredients.Remove(ingredient);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}