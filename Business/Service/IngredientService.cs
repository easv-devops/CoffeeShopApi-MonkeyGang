using Data.Repository;
using Models;
using Presentation.DTOs;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class IngredientService : IIngredientService
{
    private readonly IMapper _mapper;
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IMapper mapper, IIngredientRepository ingredientRepository)
    {
        _mapper = mapper;
        _ingredientRepository = ingredientRepository;
    }

    public IngredientDto GetIngredientById(Guid id)
    {
        var ingredient = _ingredientRepository.GetIngredientById(id);
        return _mapper.Map<IngredientDto>(ingredient);
    }

    public List<IngredientDto> GetAllIngredients()
    {
        var ingredients = _ingredientRepository.GetAllIngredients();
        return _mapper.Map<List<IngredientDto>>(ingredients);
    }

    public void AddIngredient(IngredientDto ingredientDto)
    {
        var ingredient = _mapper.Map<Ingredient>(ingredientDto);
        _ingredientRepository.AddIngredient(ingredient);
    }

    public void UpdateIngredient(IngredientDto ingredientDto)
    {
        var ingredient = _mapper.Map<Ingredient>(ingredientDto);
        _ingredientRepository.UpdateIngredient(ingredient);
    }

    public void DeleteIngredient(Guid id)
    {
        _ingredientRepository.DeleteIngredient(id);
    }
}
