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
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    
    
    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var orders = _orderService.GetAllOrdersAsync();
        
        
        
        // Map the orders to the response DTO using AutoMapper
        var responseDto = _mapper.Map<List<OrderResponseDto>>(orders);

        foreach (OrderResponseDto order in responseDto)
        {
            Console.WriteLine(order.OrderId);
        }
        
        return Ok(responseDto);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);

        if (order == null)
        {
            return NotFound();
        }

        OrderResponseDto orderResponseDto = _mapper.Map<OrderResponseDto>(order);
        
        return Ok(orderResponseDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderDto createOrderDto)
    {
        try
        {
            var orderId = await _orderService.AddOrderAsync(createOrderDto);

            // Return the newly created order's ID or other relevant information
            return Ok(new { orderId = orderId, Message = "Order created successfully." });
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            return StatusCode(500, new { Message = "Internal Server Error", Error = ex.Message });
        }
    }

    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrder(Guid orderId, [FromBody] Order updatedOrder)
    {
        if (updatedOrder == null || orderId != updatedOrder.OrderId)
        {
            return BadRequest("Invalid order data");
        }

        var existingOrder = await _orderService.GetOrderByIdAsync(orderId);

        if (existingOrder == null)
        {
            return NotFound();
        }

        await _orderService.UpdateOrderAsync(updatedOrder);

        return NoContent();
    }

    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        var existingOrder = await _orderService.GetOrderByIdAsync(orderId);

        if (existingOrder == null)
        {
            return NotFound();
        }

        await _orderService.DeleteOrderAsync(orderId);

        return NoContent();
    }
    
    
    // not testet
    [HttpPut("{orderId}/accept")]
    public IActionResult AcceptOrder(Guid orderId)
    {
        try
        {
            var order = _orderService.GetOrderByIdAsync(orderId).Result;

            if (order == null)
            {
                return NotFound($"Order with id {orderId} not found");
            }

            // Update the IsAccepted property
            order.IsAccepted = true;

            // Save changes
            _orderService.UpdateOrderAsync(order);

            return Ok($"Order with id {orderId} accepted successfully");
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
    
    
