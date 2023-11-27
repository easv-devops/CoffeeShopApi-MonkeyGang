namespace Models;

public class Product
{
    public Guid ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    //public List<OrderDetail> OrderDetails { get; set; }
}