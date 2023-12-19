namespace Models.DTOs.Response;

public class CustomCoffeeCupResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public UserResponseDto User { get; set; }
    public List<CustomCoffeeCupIngredientsResponseDto> CustomCoffeeCupIngredients { get; set; }
}