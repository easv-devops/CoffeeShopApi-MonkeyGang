using Models;

namespace Data.Repository;

public class IngredientRepository : IIngredientRepository
{
    private List<Ingredient> ingredients = new List<Ingredient>();

    public Ingredient GetIngredientById(Guid ingredientId)
    {
        return ingredients.FirstOrDefault(i => i.IngredientID == ingredientId);
    }

    public IEnumerable<Ingredient> GetAllIngredients()
    {
        return ingredients;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void UpdateIngredient(Ingredient ingredient)
    {
        // Implementation to update an ingredient in the database
    }

    public void DeleteIngredient(Guid ingredientId)
    {
        ingredients.RemoveAll(i => i.IngredientID == ingredientId);
    }
}