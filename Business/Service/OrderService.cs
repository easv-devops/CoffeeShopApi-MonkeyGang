using Data.Repository;
using Models;
using Models.DTOs;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await _orderRepository.GetOrderByIdAsync(orderId);
    }

    public async Task AddOrderAsync(Order order)
    {
        await _orderRepository.AddOrderAsync(order);
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