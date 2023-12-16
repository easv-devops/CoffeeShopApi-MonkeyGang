using Models;
using Models.DTOs;
using Models.DTOs.Create;

namespace Service;

public interface IOrderService
{
    List<Order> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Task<Guid> AddOrderAsync(CreateOrderDto order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid orderId);
}