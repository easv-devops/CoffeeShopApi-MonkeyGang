namespace Models.DTOs;

public class CoffeeBeanDto
{
    public Guid ItemId { get; set; }
    public ItemType ItemType { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
        
    // Additional properties specific to CoffeeBean
    public string Origin { get; set; }
    public string RoastLevel { get; set; }
}