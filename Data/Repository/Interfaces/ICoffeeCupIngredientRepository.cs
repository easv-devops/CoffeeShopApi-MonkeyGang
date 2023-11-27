using Models;

namespace Data.Repository.Interfaces;

public interface ICoffeeCupIngredientRepository
{
    CoffeeCupIngredient GetCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId);
    List<CoffeeCupIngredient> GetCoffeeCupIngredients(Guid coffeeCupId);
    void AddCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient);
    void UpdateCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient);
    void DeleteCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId);
}