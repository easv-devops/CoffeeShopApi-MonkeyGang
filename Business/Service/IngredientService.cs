using Data.Repository;
using Models;
using Models.DTOs;
using Models.DTOs.Response;
using Service;

namespace Business.Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMapper _mapper;

    public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
    {
        _ingredientRepository = ingredientRepository;
        _mapper = mapper;
    }

    public async Task<List<IngredientResponseDto>> GetAllIngredientsAsync()
    {
        var ingredients = await _ingredientRepository.GetAllIngredientsAsync();
        return _mapper.Map<List<IngredientResponseDto>>(ingredients);
    }

    public async Task<IngredientDto> GetIngredientByIdAsync(Guid ingredientId)
    {
        var ingredient = await _ingredientRepository.GetIngredientByIdAsync(ingredientId);
        return _mapper.Map<IngredientDto>(ingredient);
    }

    public async Task<Guid> AddIngredientAsync(IngredientDto ingredientDto)
    {
        var newIngredient = _mapper.Map<Ingredient>(ingredientDto);
        var newIngredientId = await _ingredientRepository.AddIngredientAsync(newIngredient);
        return newIngredientId;
    }

    public async Task<bool> UpdateIngredientAsync(Guid ingredientId, IngredientDto updatedIngredientDto)
    {
        var existingIngredient = await _ingredientRepository.GetIngredientByIdAsync(ingredientId);

        if (existingIngredient == null)
        {
            return false;
        }

        _mapper.Map(updatedIngredientDto, existingIngredient);

        var result = await _ingredientRepository.UpdateIngredientAsync(existingIngredient);

        return result;
    }

    public async Task<bool> DeleteIngredientAsync(Guid ingredientId)
    {
        var existingIngredient = await _ingredientRepository.GetIngredientByIdAsync(ingredientId);

        if (existingIngredient == null)
        {
            return false;
        }

        var result = await _ingredientRepository.DeleteIngredientAsync(existingIngredient);

        return result;
    }
}