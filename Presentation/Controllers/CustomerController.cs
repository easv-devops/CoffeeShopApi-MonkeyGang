using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(Guid id)
    {
        var customer = _customerService.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        var customerDto = _mapper.Map<CustomerDto>(customer);
        return Ok(customerDto);
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        var customers = _customerService.GetAllCustomers();
        var customerDtos = _mapper.Map<List<CustomerDto>>(customers);

        return Ok(customerDtos);
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] CustomerDto customerDto)
    {
        if (customerDto == null)
        {
            return BadRequest("CustomerDto cannot be null");
        }

        _customerService.AddCustomer(customerDto);

        return CreatedAtAction(nameof(GetCustomer), new { id = customerDto.CustomerId }, customerDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(Guid id, [FromBody] CustomerDto customerDto)
    {
        if (id != customerDto.CustomerId)
        {
            return BadRequest("Mismatched IDs");
        }

        _customerService.UpdateCustomer(customerDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(Guid id)
    {
        _customerService.DeleteCustomer(id);

        return NoContent();
    }
}