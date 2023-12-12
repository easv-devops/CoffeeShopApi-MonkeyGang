namespace Models.DTOs.Response;

public class IngredientResponseDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
}