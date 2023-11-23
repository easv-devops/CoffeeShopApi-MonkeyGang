using Models;

namespace Data.Repository;

public interface IIngredientRepository
{
    Ingredient GetIngredientById(Guid ingredientId);
    IEnumerable<Ingredient> GetAllIngredients();
    void AddIngredient(Ingredient ingredient);
    void UpdateIngredient(Ingredient ingredient);
    void DeleteIngredient(Guid ingredientId);
}