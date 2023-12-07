namespace Models.DTOs;

public class CoffeeBeanDto : ItemDto
{
    // Additional properties specific to CoffeeBean
    public string Origin { get; set; }
    public string RoastLevel { get; set; }
}