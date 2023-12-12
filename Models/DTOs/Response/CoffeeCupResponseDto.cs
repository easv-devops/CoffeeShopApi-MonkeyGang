using Models.DTOs.Create;
using Newtonsoft.Json;

namespace Models.DTOs.Response;

public class CoffeeCupResponseDto : ItemResponseDto
{
    [JsonProperty(Order = 3)]
    public int Size { get; set; }
    [JsonProperty(Order = 8)]
    public List<IngredientResponseDto> Ingredients { get; set; }
    
}