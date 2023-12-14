namespace Models.DTOs.Create;

public class CreateOrderDto
{
    public DateTime OrderDate { get; set; }

    public Guid StoreId { get; set; }

    public Guid CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public List<CreateOrderDetailDto> OrderDetails { get; set; }
    
}