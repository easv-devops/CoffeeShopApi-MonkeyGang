namespace Models;

public class CustomCoffeeCupIngredients
{
    
    public Guid CoffeeCupId { get; set; }
    public virtual CustomCoffeeCup CoffeeCup { get; set; }

    public Guid IngredientId { get; set; }
    public virtual Ingredient Ingredient { get; set; }

    public int Quantity { get; set; } // Represents the quantity of this ingredient in the coffee cup
}
