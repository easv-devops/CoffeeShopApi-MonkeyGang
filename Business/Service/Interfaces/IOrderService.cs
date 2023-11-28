using Models;
using Models.DTOs;

namespace Service;

public interface IOrderService
{
    OrderDto GetOrderById(Guid id);
    List<OrderDto> GetAllOrders();
    void AddOrder(OrderDto orderDto);
    void UpdateOrder(OrderDto orderDto);
    void DeleteOrder(Guid id);
}