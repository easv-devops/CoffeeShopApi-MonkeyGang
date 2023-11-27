using Data.Repository.Interfaces;
using Models;

namespace Service;

public class CoffeeCupIngredientService : ICoffeeCupIngredientService
{
    private readonly ICoffeeCupIngredientRepository _coffeeCupIngredientRepository;

    public CoffeeCupIngredientService(ICoffeeCupIngredientRepository coffeeCupIngredientRepository)
    {
        _coffeeCupIngredientRepository = coffeeCupIngredientRepository;
    }

    public CoffeeCupIngredient GetCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
    {
        return _coffeeCupIngredientRepository.GetCoffeeCupIngredient(coffeeCupId, ingredientId);
    }

    public List<CoffeeCupIngredient> GetCoffeeCupIngredients(Guid coffeeCupId)
    {
        return _coffeeCupIngredientRepository.GetCoffeeCupIngredients(coffeeCupId);
    }

    public void AddCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient)
    {
        _coffeeCupIngredientRepository.AddCoffeeCupIngredient(coffeeCupIngredient);
    }

    public void UpdateCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient)
    {
        _coffeeCupIngredientRepository.UpdateCoffeeCupIngredient(coffeeCupIngredient);
    }

    public void DeleteCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
    {
        _coffeeCupIngredientRepository.DeleteCoffeeCupIngredient(coffeeCupId, ingredientId);
    }
}