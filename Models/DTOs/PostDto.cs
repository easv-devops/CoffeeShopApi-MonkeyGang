using System.Text.Json.Serialization;

namespace Models.DTOs;

public class PostDto
{
    [JsonIgnore]
    public Guid PostId { get; set; }
    public string Text { get; set; }

    // Foreign key to refer to a specific Item in an OrderDetail
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
}