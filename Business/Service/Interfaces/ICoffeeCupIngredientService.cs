using Models;

namespace Service;

public interface ICoffeeCupIngredientService
{
    Task<CoffeeCupIngredient> GetCoffeeCupIngredientByIdAsync(Guid coffeeCupId, Guid ingredientId);
    Task<IEnumerable<CoffeeCupIngredient>> GetAllCoffeeCupIngredientsAsync(Guid coffeeCupId);
    Task AddCoffeeCupIngredientAsync(CoffeeCupIngredient coffeeCupIngredient);
    Task AddRangeCoffeeCupIngredientsAsync(IEnumerable<CoffeeCupIngredient> coffeeCupIngredients);
    Task UpdateCoffeeCupIngredientAsync(CoffeeCupIngredient coffeeCupIngredient);
    Task<bool> DeleteCoffeeCupIngredientAsync(Guid coffeeCupId, Guid ingredientId);
}