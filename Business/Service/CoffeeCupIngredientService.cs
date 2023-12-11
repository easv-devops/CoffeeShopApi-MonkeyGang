using Data.Repository.Interfaces;
using Models;
using Service;

public class CoffeeCupIngredientService : ICoffeeCupIngredientService
{
    private readonly ICoffeeCupIngredientRepository _coffeeCupIngredientRepository;

    public CoffeeCupIngredientService(ICoffeeCupIngredientRepository coffeeCupIngredientRepository)
    {
        _coffeeCupIngredientRepository = coffeeCupIngredientRepository;
    }

    public async Task<CoffeeCupIngredient> GetCoffeeCupIngredientByIdAsync(Guid coffeeCupId, Guid ingredientId)
    {
        return await _coffeeCupIngredientRepository.GetByIdAsync(coffeeCupId, ingredientId);
    }

    public async Task<IEnumerable<CoffeeCupIngredient>> GetAllCoffeeCupIngredientsAsync(Guid coffeeCupId)
    {
        return await _coffeeCupIngredientRepository.GetAllAsync(coffeeCupId);
    }

    public async Task AddCoffeeCupIngredientAsync(CoffeeCupIngredient coffeeCupIngredient)
    {
        // Add any business logic/validation as needed before calling the repository
        await _coffeeCupIngredientRepository.AddAsync(coffeeCupIngredient);
    }

    public async Task AddRangeCoffeeCupIngredientsAsync(IEnumerable<CoffeeCupIngredient> coffeeCupIngredients)
    {
        // Add any business logic/validation as needed before calling the repository
        await _coffeeCupIngredientRepository.AddRangeAsync(coffeeCupIngredients);
    }

    public async Task UpdateCoffeeCupIngredientAsync(CoffeeCupIngredient coffeeCupIngredient)
    {
        // Add any business logic/validation as needed before calling the repository
        await _coffeeCupIngredientRepository.UpdateAsync(coffeeCupIngredient);
    }

    public async Task<bool> DeleteCoffeeCupIngredientAsync(Guid coffeeCupId, Guid ingredientId)
    {
        var coffeeCupIngredient = await _coffeeCupIngredientRepository.GetByIdAsync(coffeeCupId, ingredientId);

        if (coffeeCupIngredient != null)
        {
            // Add any business logic/validation as needed before calling the repository
            await _coffeeCupIngredientRepository.DeleteAsync(coffeeCupIngredient);
            return true; // Deletion successful
        }

        return false; // CoffeeCupIngredient not found
    }
}