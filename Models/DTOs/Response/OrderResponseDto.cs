namespace Models.DTOs.Response;

public class OrderResponseDto
{
    
    public Guid OrderId { get; set; }

    public Guid StoreId { get; set; }
    public DateTime OrderDate { get; set; }



    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsAccepted { get; set; }
    public List<OrderDetailResponseDto> OrderDetails { get; set; }
}