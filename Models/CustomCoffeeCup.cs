using Newtonsoft.Json;

namespace Models;

public class CustomCoffeeCup : Item
{
    
    
    
    [JsonIgnore]
    public virtual List<CustomCoffeeCupIngredients> CustomCoffeeCupIngredients { get; set; }
    Guid UserId { get; set; }
    User User { get; set; }
    
    
}