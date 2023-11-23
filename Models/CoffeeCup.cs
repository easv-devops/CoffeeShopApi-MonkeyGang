


namespace Models;


public class CoffeeCup
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Size { get; set; }
    //decimal is used for money things 🤑
    public decimal Price { get; set; }

    // Navigation property for the many-to-many relationship
    public List<Ingredient> Ingredients { get; set; }
}