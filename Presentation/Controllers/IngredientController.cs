using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    private readonly IMapper _mapper;

    public IngredientsController(IIngredientService ingredientService, IMapper mapper)
    {
        _ingredientService = ingredientService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetIngredient(Guid id)
    {
        var ingredient = _ingredientService.GetIngredientById(id);

        if (ingredient == null)
        {
            return NotFound();
        }

        var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
        return Ok(ingredientDto);
    }

    [HttpGet]
    public IActionResult GetAllIngredients()
    {
        var ingredients = _ingredientService.GetAllIngredients();
        var ingredientDtos = _mapper.Map<List<IngredientDto>>(ingredients);

        return Ok(ingredientDtos);
    }

    [HttpPost]
    public IActionResult AddIngredient([FromBody] IngredientDto ingredientDto)
    {
        if (ingredientDto == null)
        {
            return BadRequest("IngredientDto cannot be null");
        }

        _ingredientService.AddIngredient(ingredientDto);

        return CreatedAtAction(nameof(GetIngredient), new { id = ingredientDto.IngredientID }, ingredientDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateIngredient(Guid id, [FromBody] IngredientDto ingredientDto)
    {
        if (id != ingredientDto.IngredientID)
        {
            return BadRequest("Mismatched IDs");
        }

        _ingredientService.UpdateIngredient(ingredientDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteIngredient(Guid id)
    {
        _ingredientService.DeleteIngredient(id);

        return NoContent();
    }
}