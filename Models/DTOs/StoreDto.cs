using System.Text.Json.Serialization;

namespace Models.DTOs;

public class StoreDto
{
    [JsonIgnore] public Guid StoreId { get; set; }
    public string Name { get; set; }
}