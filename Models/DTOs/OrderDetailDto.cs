using System.Text.Json.Serialization;

namespace Models.DTOs;

public class OrderDetailDto
{
    [JsonIgnore] public Guid OrderDetailId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    public Guid ItemId { get; set; }
    public ItemDto Item { get; set; }
}