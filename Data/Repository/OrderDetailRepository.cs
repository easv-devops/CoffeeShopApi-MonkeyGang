using Models;

namespace Data.Repository.Interfaces;

public class OrderDetailRepository : IOrderDetailRepository
{
    private List<OrderDetail> orderDetails = new List<OrderDetail>();

    public OrderDetail GetOrderDetailById(Guid orderDetailId)
    {
        return orderDetails.FirstOrDefault(od => od.OrderDetailID == orderDetailId);
    }

    public IEnumerable<OrderDetail> GetAllOrderDetails()
    {
        return orderDetails;
    }

    public void AddOrderDetail(OrderDetail orderDetail)
    {
        orderDetails.Add(orderDetail);
    }

    public void UpdateOrderDetail(OrderDetail orderDetail)
    {
        // Implementation to update an order detail in the database
    }

    public void DeleteOrderDetail(Guid orderDetailId)
    {
        orderDetails.RemoveAll(od => od.OrderDetailID == orderDetailId);
    }
}