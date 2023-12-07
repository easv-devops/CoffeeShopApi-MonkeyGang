using System.Text.Json.Serialization;

namespace Models.DTOs;

public class BrandDto
{
    [JsonIgnore] public Guid BrandId { get; set; }
    public string Name { get; set; }
}