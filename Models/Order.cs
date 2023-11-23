namespace Models;

public class Order
{
    public Guid OrderID { get; set; }
    public Guid CustomerID { get; set; }
    public Customer Customer { get; set; } // Navigation property
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsApproved { get; set; }

    // Navigation property for the one-to-many relationship
    public List<OrderDetail> OrderDetails { get; set; }
}