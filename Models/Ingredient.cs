namespace Models;

public class Ingredient
{
    public Guid IngredientId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    
    public Store Store { get; set; }
    
    public MeasurementUnit MeasurementUnit { get; set; }

    public List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
}