namespace Models.DTOs;

public class CoffeeCupDto : ItemDto
{
    public int Size { get; set; }

    public List<Ingredient> Ingredients { get; set; }
}