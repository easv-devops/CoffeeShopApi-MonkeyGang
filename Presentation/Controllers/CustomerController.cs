using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid id)
    {
        try
        {
            var customerDto = await _customerService.GetCustomerByIdAsync(id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }
        catch (Exception ex)
        {
            // Log the exception or return a specific error response
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
    {
        try
        {
            var customersDto = await _customerService.GetAllCustomersAsync();
            return Ok(customersDto);
        }
        catch (Exception ex)
        {
            // Log the exception or return a specific error response
            return StatusCode(500, "Internal Server Error");
        }
    }

    
    // this works now!!!!
    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromBody] CustomerDto customerDto)
    {
        try
        {
            await _customerService.AddCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerDto.CustomerId }, customerDto);
        }
        catch (Exception ex)
        {
            // Log the exception or return a specific error response
            return StatusCode(500, "Internal Server Error: " + ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomer(Guid id, [FromBody] CustomerDto customerDto)
    {
        try
        {
            if (id != customerDto.CustomerId)
            {
                return BadRequest("Mismatched customer ID");
            }

            await _customerService.UpdateCustomerAsync(customerDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception or return a specific error response
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(Guid id)
    {
        try
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception or return a specific error response
            return StatusCode(500, "Internal Server Error");
        }
    }
}