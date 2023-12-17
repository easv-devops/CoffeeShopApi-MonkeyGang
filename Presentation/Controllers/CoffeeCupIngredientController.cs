using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Models.DTOs.Response;
using Service;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeCupIngredientController : ControllerBase
    {
                private readonly ICoffeeCupIngredientService _coffeeCupIngredientService;
                private readonly IMapper _mapper;

        public CoffeeCupIngredientController(ICoffeeCupIngredientService coffeeCupIngredientService, IMapper Mapper)
        {
            _coffeeCupIngredientService = coffeeCupIngredientService;
            _mapper = Mapper;
        }

        [HttpGet("{coffeeCupId}/{ingredientId}")]
        public async Task<IActionResult> GetCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
        {
            var coffeeCupIngredient = await _coffeeCupIngredientService.GetCoffeeCupIngredientByIdAsync(coffeeCupId, ingredientId);

            if (coffeeCupIngredient == null)
            {
                return NotFound();
            }

            return Ok(coffeeCupIngredient);
        }

        [HttpGet("{coffeeCupId}")]
        public async Task<IActionResult> GetAllCoffeeCupIngredients(Guid coffeeCupId)
        {
            var coffeeCupIngredients = await _coffeeCupIngredientService.GetAllCoffeeCupIngredientsAsync(coffeeCupId);
            IEnumerable<CoffeeCupResponseDto> coffeeCupIngredientDtos = _mapper.Map<List<CoffeeCupResponseDto>>(coffeeCupIngredients);
            return Ok(coffeeCupIngredients);
        }

        [HttpPost]
        public async Task<IActionResult> AddCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient)
        {
            await _coffeeCupIngredientService.AddCoffeeCupIngredientAsync(coffeeCupIngredient);
            return CreatedAtAction(nameof(GetCoffeeCupIngredient), new { coffeeCupId = coffeeCupIngredient.CoffeeCupId, ingredientId = coffeeCupIngredient.IngredientId }, coffeeCupIngredient);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeCoffeeCupIngredients(IEnumerable<CoffeeCupIngredient> coffeeCupIngredients)
        {
            await _coffeeCupIngredientService.AddRangeCoffeeCupIngredientsAsync(coffeeCupIngredients);
            return CreatedAtAction(nameof(GetAllCoffeeCupIngredients), new { coffeeCupId = coffeeCupIngredients.First().CoffeeCupId }, coffeeCupIngredients);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient)
        {
            await _coffeeCupIngredientService.UpdateCoffeeCupIngredientAsync(coffeeCupIngredient);
            return Ok();
        }

        [HttpDelete("{coffeeCupId}/{ingredientId}")]
        public async Task<IActionResult> DeleteCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
        {
            await _coffeeCupIngredientService.DeleteCoffeeCupIngredientAsync(coffeeCupId, ingredientId);

            
                return NotFound();
            
        }
    }
}