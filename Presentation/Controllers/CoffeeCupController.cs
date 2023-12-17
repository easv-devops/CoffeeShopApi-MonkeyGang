using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Service;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeCupController : ControllerBase
{
    private readonly ICoffeeCupService _coffeeCupService;
    private readonly IMapper _mapper;


    public CoffeeCupController(IMapper mapper, ICoffeeCupService coffeeCupService)
    {
        _mapper = mapper;
        _coffeeCupService = coffeeCupService;
    }

    [HttpGet("{coffeeCupId}")]
    public async Task<IActionResult> GetCoffeeCup(Guid coffeeCupId)
    {
        CoffeeCup coffeeCup = await _coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

        if (coffeeCup == null)
        {
            return NotFound();
        }

        var coffeeCupDto = _mapper.Map<CoffeeCupResponseDto>(coffeeCup);

        return Ok(coffeeCupDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCoffeeCups()
    {
        IEnumerable<CoffeeCup> coffeeCups = await _coffeeCupService.GetAllCoffeeCupsAsync();


        var coffeeCupDtos = _mapper.Map<List<CoffeeCupResponseDto>>(coffeeCups);

        //todo: this is a hack to get the quantity of each ingredient in the coffee cup
        // WARNING: THIS IS A EXTREME LEVEL OF JANK AND SHOULD NOT BE USED IN PRODUCTION
        /*
         *(╯°□°)╯︵ ┻━┻
         *(ノಠ益ಠ)ノ彡┻━┻
         * (┛◉Д◉)┛彡┻━┻
         */

        foreach (var coffeeCupDto in coffeeCupDtos)
        {
            foreach (var ingredientDto in coffeeCupDto.Ingredients)
            {
                // Modify the quantity or perform any other modifications as needed
                var coffeeCupIngredient = coffeeCups
                    .SelectMany(cc => cc.CoffeeCupIngredients)
                    .FirstOrDefault(cci => cci.Ingredient.IngredientId == ingredientDto.IngredientId);

                if (coffeeCupIngredient != null)
                {
                    ingredientDto.Quantity = coffeeCupIngredient.Quantity;
                }
            }
        }


        return Ok(coffeeCupDtos);
    }


    [HttpPost("create")]
    public async Task<IActionResult> CreateCoffeeCup([FromBody] CreateCoffeeCupDto createCoffeeCupDto)
    {
        try
        {
            // Map CreateCoffeeCupDto to CoffeeCup entity using AutoMapper
            var coffeeCup = _mapper.Map<CoffeeCup>(createCoffeeCupDto);

            // Add coffee cup to the database and get the generated ID
            var generatedId = await _coffeeCupService.AddCoffeeCupAsync(coffeeCup);

            // Map the created coffee cup to a response DTO using AutoMapper
            var responseDto = _mapper.Map<CoffeeCupResponseDto>(coffeeCup);
            responseDto.ItemId = generatedId;

            // Return the created coffee cup response with a 201 status code ʕ•ᴥ•ʔ
            return CreatedAtAction(nameof(GetCoffeeCup), new { coffeeCupId = generatedId }, responseDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return BadRequest("Failed to create coffee cup.");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCoffeeCup(CoffeeCup coffeeCup)
    {
        await _coffeeCupService.UpdateCoffeeCupAsync(coffeeCup);
        return Ok();
    }

    [HttpDelete("{coffeeCupId}")]
    public async Task<IActionResult> DeleteCoffeeCup(Guid coffeeCupId)
    {
        var deletionResult = await _coffeeCupService.DeleteCoffeeCupAsync(coffeeCupId);

        if (deletionResult)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpGet("{id}/cakes")]
    public async Task<IActionResult> GetCakesForCoffeeCup(Guid id)
    {
        var cakesForCoffeeCupDto = await _coffeeCupService.GetCakesForCoffeeCupAsync(id);

        if (cakesForCoffeeCupDto == null)
        {
            return NotFound();
        }

        return Ok(cakesForCoffeeCupDto);
    }
    
    
}