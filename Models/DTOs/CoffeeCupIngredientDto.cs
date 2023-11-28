namespace Models.DTOs;

public class CoffeeCupIngredientDto
{
    public Guid CoffeeCupId { get; set; }
    public Ingredient Ingredient { get; set; }
    public Guid IngredientId { get; set; }
    public int Quantity { get; set; }
}