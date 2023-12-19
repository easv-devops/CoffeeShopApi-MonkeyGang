using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Models.DTOs.Response;

public class ItemResponseDto
{
    [JsonProperty(Order = 1)] public Guid ItemId { get; set; }

    [JsonProperty(Order = 3)] public ItemType ItemType { get; set; } 

    [JsonProperty(Order = 2)] public string Name { get; set; }
    [JsonProperty(Order = 4)] public string Description { get; set; }
    [JsonProperty(Order = 5)] public decimal Price { get; set; }

    [JsonProperty(Order = 6)] public string Image { get; set; }
    [JsonProperty(Order = 7)] public List<Guid> StoreIds { get; set; }
}