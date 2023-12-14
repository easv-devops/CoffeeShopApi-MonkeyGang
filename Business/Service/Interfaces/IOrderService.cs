using Models;
using Models.DTOs;

namespace Service;

public interface IOrderService
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid orderId);
}