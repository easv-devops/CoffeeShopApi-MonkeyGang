using Models;
using Presentation.DTOs;

namespace Service;

public interface IOrderDetailService
{
    OrderDetailDto GetOrderDetailById(Guid id);
    List<OrderDetailDto> GetAllOrderDetails();
    void AddOrderDetail(OrderDetailDto orderDetailDto);
    void UpdateOrderDetail(OrderDetailDto orderDetailDto);
    void DeleteOrderDetail(Guid id);
}