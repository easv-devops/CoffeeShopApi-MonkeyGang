namespace Presentation.DTOs;

public class OrderDto
{
    public Guid OrderID { get; set; }
    public Guid CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }
    public decimal TotalAmount { get; set; }
}