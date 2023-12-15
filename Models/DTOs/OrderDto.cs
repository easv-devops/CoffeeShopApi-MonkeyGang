using System.Text.Json.Serialization;

namespace Models.DTOs;

public class OrderDto
{
    [JsonIgnore] public Guid OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid UserID { get; set; }
    public Guid StoreID { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsAccepted { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }
}