using System;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Service;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeCupIngredientController : ControllerBase
    {
        private readonly ICoffeeCupIngredientService _coffeeCupIngredientService;

        public CoffeeCupIngredientController(ICoffeeCupIngredientService coffeeCupIngredientService)
        {
            _coffeeCupIngredientService = coffeeCupIngredientService;
        }

        [HttpGet("{coffeeCupId}/{ingredientId}")]
        public IActionResult GetCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
        {
            var coffeeCupIngredient = _coffeeCupIngredientService.GetCoffeeCupIngredient(coffeeCupId, ingredientId);

            if (coffeeCupIngredient == null)
            {
                return NotFound();
            }

            var coffeeCupIngredientDto = new CoffeeCupIngredientDto
            {
                CoffeeCupId = coffeeCupIngredient.CoffeeCupId,
                IngredientId = coffeeCupIngredient.IngredientId,
                Quantity = coffeeCupIngredient.Quantity
            };

            return Ok(coffeeCupIngredientDto);
        }

        [HttpGet("{coffeeCupId}")]
        public IActionResult GetCoffeeCupIngredients(Guid coffeeCupId)
        {
            var coffeeCupIngredients = _coffeeCupIngredientService.GetCoffeeCupIngredients(coffeeCupId);

            var coffeeCupIngredientDtos = coffeeCupIngredients.ConvertAll(cci =>
                new CoffeeCupIngredientDto
                {
                    CoffeeCupId = cci.CoffeeCupId,
                    IngredientId = cci.IngredientId,
                    Quantity = cci.Quantity
                });

            return Ok(coffeeCupIngredientDtos);
        }

        [HttpPost]
        public IActionResult AddCoffeeCupIngredient([FromBody] CoffeeCupIngredientDto coffeeCupIngredientDto)
        {
            if (coffeeCupIngredientDto == null)
            {
                return BadRequest("CoffeeCupIngredientDto cannot be null");
            }

            var coffeeCupIngredient = new CoffeeCupIngredient
            {
                CoffeeCupId = coffeeCupIngredientDto.CoffeeCupId,
                IngredientId = coffeeCupIngredientDto.IngredientId,
                Quantity = coffeeCupIngredientDto.Quantity
            };

            _coffeeCupIngredientService.AddCoffeeCupIngredient(coffeeCupIngredient);

            return CreatedAtAction(nameof(GetCoffeeCupIngredient),
                new { coffeeCupId = coffeeCupIngredient.CoffeeCupId, ingredientId = coffeeCupIngredient.IngredientId },
                coffeeCupIngredientDto);
        }

        [HttpPut("{coffeeCupId}/{ingredientId}")]
        public IActionResult UpdateCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId,
            [FromBody] CoffeeCupIngredientDto coffeeCupIngredientDto)
        {
            if (coffeeCupIngredientDto == null)
            {
                return BadRequest("CoffeeCupIngredientDto cannot be null");
            }

            if (coffeeCupId != coffeeCupIngredientDto.CoffeeCupId ||
                ingredientId != coffeeCupIngredientDto.IngredientId)
            {
                return BadRequest("Mismatched IDs");
            }

            var coffeeCupIngredient = new CoffeeCupIngredient
            {
                CoffeeCupId = coffeeCupId,
                IngredientId = ingredientId,
                Quantity = coffeeCupIngredientDto.Quantity
            };

            _coffeeCupIngredientService.UpdateCoffeeCupIngredient(coffeeCupIngredient);

            return NoContent();
        }

        [HttpDelete("{coffeeCupId}/{ingredientId}")]
        public IActionResult DeleteCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
        {
            _coffeeCupIngredientService.DeleteCoffeeCupIngredient(coffeeCupId, ingredientId);

            return NoContent();
        }
    }
}