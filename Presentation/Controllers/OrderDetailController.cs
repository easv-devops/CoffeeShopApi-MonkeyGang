using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMapper _mapper;

    public OrderDetailsController(IOrderDetailService orderDetailService, IMapper mapper)
    {
        _orderDetailService = orderDetailService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderDetail(Guid id)
    {
        var orderDetail = _orderDetailService.GetOrderDetailById(id);

        if (orderDetail == null)
        {
            return NotFound();
        }

        var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
        return Ok(orderDetailDto);
    }

    [HttpGet]
    public IActionResult GetAllOrderDetails()
    {
        var orderDetails = _orderDetailService.GetAllOrderDetails();
        var orderDetailDtos = _mapper.Map<List<OrderDetailDto>>(orderDetails);

        return Ok(orderDetailDtos);
    }

    [HttpPost]
    public IActionResult AddOrderDetail([FromBody] OrderDetailDto orderDetailDto)
    {
        if (orderDetailDto == null)
        {
            return BadRequest("OrderDetailDto cannot be null");
        }

        _orderDetailService.AddOrderDetail(orderDetailDto);

        return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetailDto.OrderDetailId }, orderDetailDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrderDetail(Guid id, [FromBody] OrderDetailDto orderDetailDto)
    {
        if (id != orderDetailDto.OrderDetailId)
        {
            return BadRequest("Mismatched IDs");
        }

        _orderDetailService.UpdateOrderDetail(orderDetailDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrderDetail(Guid id)
    {
        _orderDetailService.DeleteOrderDetail(id);

        return NoContent();
    }
}