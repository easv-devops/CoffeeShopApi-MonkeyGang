using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
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
}