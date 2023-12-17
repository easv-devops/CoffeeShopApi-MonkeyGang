namespace Models.DTOs.Create;

public class CustomCoffeeCupCreateDto
{
    public string Name { get; set; }
    public List<Guid> IngredientIds { get; set; }
    public Guid UserId { get; set; }
}