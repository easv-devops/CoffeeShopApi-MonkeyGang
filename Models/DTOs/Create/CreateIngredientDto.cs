namespace Models.DTOs.Create;

public class CreateIngredientDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
}