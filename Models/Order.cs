namespace Models;

public class Order
{
    public Guid OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid CustomerID { get; set; }
    public Customer Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsAccepted { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}