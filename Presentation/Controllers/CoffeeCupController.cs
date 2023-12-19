using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeCupController : ControllerBase
    {
        private readonly ICoffeeCupService _coffeeCupService;

        public CoffeeCupController(ICoffeeCupService coffeeCupService)
        {
            _coffeeCupService = coffeeCupService;
        }

        [HttpGet("{coffeeCupId}")]
        public async Task<IActionResult> GetCoffeeCup(Guid coffeeCupId)
        {
            var coffeeCupResponseDto = await _coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

            // If the coffee cup doesn't exist, return a 404 Not Found
            if (coffeeCupResponseDto.ItemId == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(coffeeCupResponseDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoffeeCups()
        {
            var coffeeCupDtos = await _coffeeCupService.GetAllCoffeeCupsAsync();

            return Ok(coffeeCupDtos);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCoffeeCup([FromBody] CreateCoffeeCupDto createCoffeeCupDto)
        {
            try
            {
                var generatedId = await _coffeeCupService.AddCoffeeCupAsync(createCoffeeCupDto);

                // Return the created coffee cup response with a 201 status code
                return CreatedAtAction(nameof(GetCoffeeCup), new { coffeeCupId = generatedId }, createCoffeeCupDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Failed to create coffee cup.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoffeeCup([FromBody] CoffeeCupResponseDto coffeeCupDto)
        {
            await _coffeeCupService.UpdateCoffeeCupAsync(coffeeCupDto.ItemId,coffeeCupDto);
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

            if (cakesForCoffeeCupDto.Count == 0)
            {
                return NotFound();
            }

            return Ok(cakesForCoffeeCupDto);
        }
    }
}
