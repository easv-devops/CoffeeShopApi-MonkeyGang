using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICustomerService _customerService;

    public CustomerController(IMapper mapper ,ICustomerService customerService)
    {
        _mapper = mapper;   
        _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
    }

    [HttpGet("{customerId}")] // This route should match the route used in CreatedAtAction
    public async Task<IActionResult> GetCustomer(Guid customerId)
    {
        try
        {
            // Retrieve the customer by ID using the service
            var customer = await _customerService.GetCustomerAsync(customerId);

            // Check if the customer exists
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            // Map the customer to the response DTO using AutoMapper
            var responseDto = _mapper.Map<CustomerResponseDto>(customer);

            // Return the customer response
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            return BadRequest("Failed to retrieve customer.");
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


    [HttpPost("add")]
    public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerDto createCustomerDto)
    {
        try
        {
            // Map CreateCustomerDto to Customer entity using AutoMapper
            var customer = _mapper.Map<Customer>(createCustomerDto);

            // Add customer to the database and get the generated ID
            var generatedId = await _customerService.AddCustomerAsync(customer);

            // Map the created customer to a response DTO using AutoMapper
            var responseDto = _mapper.Map<CustomerResponseDto>(customer);
            responseDto.CustomerId = generatedId;

            // Return the created customer response
            return CreatedAtAction(nameof(GetCustomer), new { customerId = generatedId }, responseDto);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            return BadRequest("Failed to create customer.");
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