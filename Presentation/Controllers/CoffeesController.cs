namespace Presentation.Controllers;

using DTOs;

using AutoMapper;
using Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CoffeeCupController : ControllerBase
{
    private readonly ICoffeeCupService _coffeeCupService;
    private readonly IMapper _mapper;

    public CoffeeCupController(ICoffeeCupService coffeeCupService, IMapper mapper)
    {
        _coffeeCupService = coffeeCupService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetCoffeeCup(Guid id)
    {
        var coffeeCup = _coffeeCupService.GetCoffeeCupById(id);

        if (coffeeCup == null)
        {
            return NotFound();
        }

        var coffeeCupDto = _mapper.Map<CoffeeCupDto>(coffeeCup);
        return Ok(coffeeCupDto);
    }

    [HttpGet]
    public IActionResult GetAllCoffeeCups()
    {
        var coffeeCups = _coffeeCupService.GetAllCoffeeCups();
        var coffeeCupDtos = _mapper.Map<List<CoffeeCupDto>>(coffeeCups);

        return Ok(coffeeCupDtos);
    }

    [HttpPost]
    public IActionResult AddCoffeeCup([FromBody] CoffeeCupDto coffeeCupDto)
    {
        if (coffeeCupDto == null)
        {
            return BadRequest("CoffeeCupDto cannot be null");
        }

        _coffeeCupService.AddCoffeeCup(coffeeCupDto);

        return CreatedAtAction(nameof(GetCoffeeCup), new { id = coffeeCupDto.CupID }, coffeeCupDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCoffeeCup(Guid id, [FromBody] CoffeeCupDto coffeeCupDto)
    {
        if (id != coffeeCupDto.CupID)
        {
            return BadRequest("Mismatched IDs");
        }

        _coffeeCupService.UpdateCoffeeCup(coffeeCupDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCoffeeCup(Guid id)
    {
        _coffeeCupService.DeleteCoffeeCup(id);

        return NoContent();
    }
}