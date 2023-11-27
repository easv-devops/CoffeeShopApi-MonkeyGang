namespace Models;

public class CoffeeCupIngredient
{
    public Guid CoffeeCupId { get; set; }
    public CoffeeCup CoffeeCup { get; set; }

    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }

    public int Quantity { get; set; } // Represents the quantity of this ingredient in the coffee cup
}