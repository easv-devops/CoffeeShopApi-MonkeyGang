using Models;

namespace Data.Repository.Interfaces;

public interface ICoffeeCupIngredientRepository
{
    Task<CoffeeCupIngredient> GetByIdAsync(Guid coffeeCupId, Guid ingredientId);
    Task<IEnumerable<CoffeeCupIngredient>> GetAllAsync(Guid coffeeCupId);
    Task AddAsync(CoffeeCupIngredient coffeeCupIngredient);
    Task AddRangeAsync(IEnumerable<CoffeeCupIngredient> coffeeCupIngredients);
    Task UpdateAsync(CoffeeCupIngredient coffeeCupIngredient);
    Task DeleteAsync(CoffeeCupIngredient coffeeCupIngredient);
}