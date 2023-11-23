using Models;

namespace Data.Repository;

public interface IOrderDetailRepository
{
    OrderDetail GetOrderDetailById(Guid orderDetailId);
    IEnumerable<OrderDetail> GetAllOrderDetails();
    void AddOrderDetail(OrderDetail orderDetail);
    void UpdateOrderDetail(OrderDetail orderDetail);
    void DeleteOrderDetail(Guid orderDetailId);
}