using Models;
using Presentation.DTOs;

namespace Service;

public interface IIngredientService
{
    IngredientDto GetIngredientById(Guid id);
    List<IngredientDto> GetAllIngredients();
    void AddIngredient(IngredientDto ingredientDto);
    void UpdateIngredient(IngredientDto ingredientDto);
    void DeleteIngredient(Guid id);
}