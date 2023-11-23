using Models;

namespace Data.Repository;

public class OrderRepository : IOrderRepository
{
    private List<Order> orders = new List<Order>();

    public Order GetOrderById(Guid orderId)
    {
        return orders.FirstOrDefault(o => o.OrderID == orderId);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return orders;
    }

    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    public void UpdateOrder(Order order)
    {
        // Implementation to update an order in the database
    }

    public void DeleteOrder(Guid orderId)
    {
        orders.RemoveAll(o => o.OrderID == orderId);
    }
}