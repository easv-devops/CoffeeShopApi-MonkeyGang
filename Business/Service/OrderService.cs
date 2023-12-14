using Data.Repository;
using Models;
using Models.DTOs;
using Models.DTOs.Create;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await _orderRepository.GetOrderByIdAsync(orderId);
    }

    public async Task<Guid> AddOrderAsync(CreateOrderDto createOrderDto)
    {
        var orderEntity = _mapper.Map<Order>(createOrderDto);


        if (orderEntity.OrderId == Guid.Empty)
        {
            throw new ArgumentException("Order Id cannot be empty");
        }
        
        var orderId = await _orderRepository.AddOrderAsync(orderEntity);

        return orderId;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        //check if guid is empty
        if (order.OrderId == Guid.Empty)
        {
            throw new ArgumentException("Order Id cannot be empty");
        }
        
        //check if order exists
        var existingOrder = await _orderRepository.GetOrderByIdAsync(order.OrderId);
        if (existingOrder == null)
        {
            throw new ArgumentException($"Order with id {order.OrderId} does not exist");
        }
        
        
        await _orderRepository.UpdateOrderAsync(order);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        await _orderRepository.DeleteOrderAsync(orderId);
    }
}