using Microsoft.AspNetCore.Mvc;
using Models;
using Service;


namespace Presentation.Controllers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/brands")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        var brands = await _brandService.GetAllBrandsAsync();
        return Ok(brands);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(Guid id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);

        if (brand == null)
        {
            return NotFound();
        }

        return Ok(brand);
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand([FromBody] Brand brand)
    {
        if (brand == null)
        {
            return BadRequest("Brand object is null");
        }

        await _brandService.AddBrandAsync(brand);

        return CreatedAtAction(nameof(GetBrandById), new { id = brand.BrandId }, brand);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrand(Guid id, [FromBody] Brand brand)
    {
        if (brand == null || id != brand.BrandId)
        {
            return BadRequest("Invalid request");
        }

        var existingBrand = await _brandService.GetBrandByIdAsync(id);
        if (existingBrand == null)
        {
            return NotFound();
        }

        await _brandService.UpdateBrandAsync(brand);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);
        if (brand == null)
        {
            return NotFound();
        }

        await _brandService.DeleteBrandAsync(id);

        return NoContent();
    }
}