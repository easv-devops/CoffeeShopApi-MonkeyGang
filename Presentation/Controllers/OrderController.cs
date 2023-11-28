using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(Guid id)
    {
        var order = _orderService.GetOrderById(id);

        if (order == null)
        {
            return NotFound();
        }

        var orderDto = _mapper.Map<OrderDto>(order);
        return Ok(orderDto);
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var orders = _orderService.GetAllOrders();
        var orderDtos = _mapper.Map<List<OrderDto>>(orders);

        return Ok(orderDtos);
    }

    [HttpPost]
    public IActionResult AddOrder([FromBody] OrderDto orderDto)
    {
        if (orderDto == null)
        {
            return BadRequest("OrderDto cannot be null");
        }

        _orderService.AddOrder(orderDto);

        return CreatedAtAction(nameof(GetOrder), new { id = orderDto.OrderID }, orderDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(Guid id, [FromBody] OrderDto orderDto)
    {
        if (id != orderDto.OrderID)
        {
            return BadRequest("Mismatched IDs");
        }

        _orderService.UpdateOrder(orderDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(Guid id)
    {
        _orderService.DeleteOrder(id);

        return NoContent();
    }
}