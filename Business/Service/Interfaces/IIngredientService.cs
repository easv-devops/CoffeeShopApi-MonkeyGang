using Models;
using Models.DTOs;
using Models.DTOs.Response;

namespace Service;

public interface IIngredientService
{
    Task<IngredientDto> GetIngredientByIdAsync(Guid id);
    Task<List<IngredientResponseDto>> GetAllIngredientsAsync();
    Task<Guid> AddIngredientAsync(IngredientDto ingredientDto);
    Task<bool> UpdateIngredientAsync(Guid ingredientId, IngredientDto updatedIngredientDto);
    Task<bool> DeleteIngredientAsync(Guid id);
}