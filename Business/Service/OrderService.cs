using Data.Repository;
using Models;
using Presentation.DTOs;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public OrderDto GetOrderById(Guid id)
    {
        var order = _orderRepository.GetOrderById(id);
        return _mapper.Map<OrderDto>(order);
    }

    public List<OrderDto> GetAllOrders()
    {
        var orders = _orderRepository.GetAllOrders();
        return _mapper.Map<List<OrderDto>>(orders);
    }

    public void AddOrder(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        _orderRepository.AddOrder(order);
    }

    public void UpdateOrder(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        _orderRepository.UpdateOrder(order);
    }

    public void DeleteOrder(Guid id)
    {
        _orderRepository.DeleteOrder(id);
    }
}
