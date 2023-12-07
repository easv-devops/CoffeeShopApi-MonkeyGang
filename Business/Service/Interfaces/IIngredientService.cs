using Models;
using Models.DTOs;

namespace Service;

public interface IIngredientService
{
    Task<IngredientDto> GetIngredientByIdAsync(Guid id);
    Task<List<IngredientDto>> GetAllIngredientsAsync();
    Task<Guid> AddIngredientAsync(IngredientDto ingredientDto);
    Task<bool> UpdateIngredientAsync(Guid ingredientId, IngredientDto updatedIngredientDto);
    Task<bool> DeleteIngredientAsync(Guid id);
}