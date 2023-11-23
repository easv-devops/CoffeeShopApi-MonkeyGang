namespace Models;

public class OrderDetail
{
    public Guid OrderDetailID { get; set; }
    public Guid OrderID { get; set; }
    public Order Order { get; set; } // Navigation property
    public Guid ItemID { get; set; }
    public string ItemType { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}