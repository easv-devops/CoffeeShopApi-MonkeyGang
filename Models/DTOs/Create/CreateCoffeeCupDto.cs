using System.Text.Json.Serialization;

namespace Models.DTOs.Create;

public class CreateCoffeeCupDto : ItemDto
{
    // Item properties
    [JsonIgnore]
    public ItemType ItemType => ItemType.CoffeeCup;
    
    

    // CoffeeCup-specific properties
    public int Size { get; set; }

    // Ingredients for creation
    public List<CreateIngredientDto> Ingredients { get; set; }
}