using Models;

namespace Data.Repository;

public interface IOrderRepository
{
    List<Order> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Task<Guid> AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid orderId);
}