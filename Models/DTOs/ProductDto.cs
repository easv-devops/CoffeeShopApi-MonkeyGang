namespace Presentation.DTOs;

public class ProductDto
{
    public Guid ProductID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public int StockQuantity { get; set; }
    
}