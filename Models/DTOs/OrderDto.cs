namespace Models.DTOs;

public class OrderDto
{
    public Guid OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid CustomerID { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsAccepted { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }
}