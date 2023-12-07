using System.Text.Json.Serialization;

namespace Models.DTOs;

public class IngredientDto
{
    [JsonIgnore]
    public Guid IngredientId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    //public int StockQuantity { get; set; }
    //public StoreDto Store { get; set; }
    public MeasurementUnit MeasurementUnit { get; set; }
    public List<CoffeeCupIngredientDto> CoffeeCupIngredients { get; set; }
}