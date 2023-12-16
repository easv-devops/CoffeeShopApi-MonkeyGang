namespace Models.DTOs.Response;

public class OrderDetailResponseDto
{
    public Guid OrderDetailId { get; set; }

    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }

    public Guid ItemId { get; set; }

}