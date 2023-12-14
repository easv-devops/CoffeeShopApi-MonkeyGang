namespace Models.DTOs.Response;

public class IngredientResponseDto
{
    public Guid IngredientId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
}