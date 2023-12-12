namespace Models.DTOs.Response;

public class CoffeeCupResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Size { get; set; }
    public Guid StoreId { get; set; }
    
    
    public List<IngredientResponseDto> Ingredients { get; set; }
    
}