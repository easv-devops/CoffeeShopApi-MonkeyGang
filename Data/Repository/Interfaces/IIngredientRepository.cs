using Models;

namespace Data.Repository;

public interface IIngredientRepository
{
    Task<List<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(Guid ingredientId);
    Task<Guid> AddIngredientAsync(Ingredient ingredient);
    Task<bool> UpdateIngredientAsync(Ingredient ingredient);
    Task<bool> DeleteIngredientAsync(Ingredient ingredient);
}