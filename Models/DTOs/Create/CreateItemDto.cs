namespace Models.DTOs.Create;

public class CreateItemDto
{
 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Guid StoreId { get; set; }
}