namespace Presentation.DTOs;

public class OrderDetailDto
{
    public Guid OrderDetailID { get; set; }
    public Guid OrderID { get; set; }
    public Guid ItemID { get; set; }
    public string ItemType { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}