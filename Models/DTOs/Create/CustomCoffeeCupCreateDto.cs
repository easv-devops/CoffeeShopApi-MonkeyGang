namespace Models.DTOs.Create;

public class CustomCoffeeCupCreateDto : ItemDto
{
    public List<CreateCustomCoffeeCupIngredientsDto> Ingredients { get; set; }
    public Guid UserId { get; set; }
    public ItemType ItemType => ItemType.CoffeeCup;
    //set price later
}