using System.Text.Json.Serialization;

namespace Models.DTOs.Create;

public class CreateCoffeeCupDto : CreateItemDto
{
    public ItemType ItemType => ItemType.CoffeeCup;


    public int Size { get; set; }

    public List<CreateIngredientDto> Ingredients { get; set; }
}