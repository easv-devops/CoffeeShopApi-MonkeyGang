using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Service;

[ApiController]
[Route("api/customcoffeecups")]
public class CustomCoffeeCupController : ControllerBase
{
    private readonly ICustomCoffeeCupService _customCoffeeCupService;

    public CustomCoffeeCupController(ICustomCoffeeCupService customCoffeeCupService)
    {
        _customCoffeeCupService = customCoffeeCupService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomCoffeeCup(Guid id)
    {
        var customCoffeeCupDto = await _customCoffeeCupService.GetCustomCoffeeCupByIdAsync(id);

        if (customCoffeeCupDto.ToString() == null)
        {
            return NotFound();
        }

        return Ok(customCoffeeCupDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomCoffeeCups()
    {
        var customCoffeeCupsDto = await _customCoffeeCupService.GetAllCustomCoffeeCupsAsync();
        return Ok(customCoffeeCupsDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomCoffeeCup([FromBody] CustomCoffeeCupCreateDto createDto)
    {
        var createdCustomCoffeeCupId = await _customCoffeeCupService.CreateCustomCoffeeCupAsync(createDto);

        return CreatedAtAction(nameof(GetCustomCoffeeCup), new { id = createdCustomCoffeeCupId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomCoffeeCup(Guid id, [FromBody] CustomCoffeeCupDto updateDto)
    {
        var updatedCustomCoffeeCupDto = await _customCoffeeCupService.UpdateCustomCoffeeCupAsync(id, updateDto);

        if (updatedCustomCoffeeCupDto == null)
        {
            return NotFound();
        }

        return Ok(updatedCustomCoffeeCupDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomCoffeeCup(Guid id)
    {
        var isDeleted = await _customCoffeeCupService.DeleteCustomCoffeeCupAsync(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}