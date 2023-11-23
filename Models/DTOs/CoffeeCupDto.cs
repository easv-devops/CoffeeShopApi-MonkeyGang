namespace Presentation.DTOs;

public class CoffeeCupDto
{
    public Guid CupID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<CoffeeCupIngredientDto> Ingredients { get; set; }
}