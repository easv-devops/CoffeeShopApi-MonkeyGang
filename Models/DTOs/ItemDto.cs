using System.Text.Json.Serialization;

namespace Models.DTOs;

public class ItemDto
{
    [JsonIgnore] public Guid ItemId { get; set; }
    public ItemType ItemType { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public Guid StoreId { get; set; }

}