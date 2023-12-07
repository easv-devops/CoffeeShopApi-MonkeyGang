using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<ActionResult<List<IngredientDto>>> GetAllIngredients()
    {
        var ingredients = await _ingredientService.GetAllIngredientsAsync();
        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientDto>> GetIngredientById(Guid id)
    {
        var ingredient = await _ingredientService.GetIngredientByIdAsync(id);

        //Expression is always false according to nullable reference types' annotations
        if (ingredient == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddIngredient([FromBody] IngredientDto ingredientDto)
    {
        var newIngredientId = await _ingredientService.AddIngredientAsync(ingredientDto);
        return CreatedAtAction(nameof(GetIngredientById), new { id = newIngredientId }, newIngredientId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateIngredient(Guid id, [FromBody] IngredientDto updatedIngredientDto)
    {
        var result = await _ingredientService.UpdateIngredientAsync(id, updatedIngredientDto);

        if (!result)
        {
            return NotFound(); // 404 Not Found
        }

        return NoContent(); // 204 No Content
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteIngredient(Guid id)
    {
        var result = await _ingredientService.DeleteIngredientAsync(id);

        if (!result)
        {
            return NotFound(); // 404 Not Found
        }

        return NoContent(); // 204 No Content
    }
}