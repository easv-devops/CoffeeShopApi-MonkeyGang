namespace Models.DTOs.Create;

public class CreateCoffeeCupIngredientDto
{
    public CreateIngredientDto Ingredient { get; set; }
    public int Quantity { get; set; }
}