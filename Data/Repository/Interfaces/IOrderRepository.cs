using Models;

namespace Data.Repository;

public interface IOrderRepository
{
    Order GetOrderById(Guid orderId);
    IEnumerable<Order> GetAllOrders();
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Guid orderId);
}