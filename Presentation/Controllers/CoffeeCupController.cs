

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Service;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeCupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoffeeCupService _coffeeCupService;

        public CoffeeCupController(IMapper mapper, ICoffeeCupService coffeeCupService)
        {
            _mapper = mapper;
            _coffeeCupService = coffeeCupService;
        }

        [HttpGet("{coffeeCupId}")]
        public async Task<IActionResult> GetCoffeeCup(Guid coffeeCupId)
        {
            var coffeeCup = await _coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

            if (coffeeCup == null)
            {
                return NotFound();
            }

            return Ok(coffeeCup);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoffeeCups()
        {
            var coffeeCups = await _coffeeCupService.GetAllCoffeeCupsAsync();
            return Ok(coffeeCups);
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
                responseDto.Id = generatedId;

                // Return the created coffee cup response
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
    }
}