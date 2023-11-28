using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(Guid id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        var productDto = _mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _productService.GetAllProducts();
        var productDtos = _mapper.Map<List<ProductDto>>(products);

        return Ok(productDtos);
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] ProductDto productDto)
    {
        if (productDto == null)
        {
            return BadRequest("ProductDto cannot be null");
        }

        _productService.AddProduct(productDto);

        return CreatedAtAction(nameof(GetProduct), new { id = productDto.ProductID }, productDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(Guid id, [FromBody] ProductDto productDto)
    {
        if (id != productDto.ProductID)
        {
            return BadRequest("Mismatched IDs");
        }

        _productService.UpdateProduct(productDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
        _productService.DeleteProduct(id);

        return NoContent();
    }
}