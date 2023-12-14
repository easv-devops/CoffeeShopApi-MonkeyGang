using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
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
    public async Task<IActionResult> AddOrder([FromBody] Order order)
    {
        if (order == null)
        {
            return BadRequest("Invalid order data");
        }

        await _orderService.AddOrderAsync(order);

        return CreatedAtAction(nameof(GetOrderById), new { orderId = order.OrderId }, order);
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