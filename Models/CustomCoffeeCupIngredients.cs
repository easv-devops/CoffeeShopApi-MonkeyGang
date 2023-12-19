namespace Models;

public class CustomCoffeeCupIngredients
{
    public Guid CustomCoffeeCupId { get; set; }
    public virtual CustomCoffeeCup CustomCoffeeCup { get; set; }

    public Guid IngredientId { get; set; }
    public virtual Ingredient Ingredient { get; set; }
}