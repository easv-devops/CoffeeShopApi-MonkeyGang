using Newtonsoft.Json;

namespace Models;

public class CustomCoffeeCup : Item
{
    [JsonIgnore] public virtual List<CustomCoffeeCupIngredients> CustomCoffeeCupIngredients { get; set; }
    public virtual Guid UserId { get; set; }
    public virtual User User { get; set; }
}