namespace Presentation.DTOs;

public class IngredientDto
{
    public Guid IngredientID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}