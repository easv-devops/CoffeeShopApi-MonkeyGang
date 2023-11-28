using System.ComponentModel.DataAnnotations;

namespace Models;

public class Item
{
    
    [Key]
    public Guid ItemId { get; set; }
    public ItemType ItemType { get; set; } // Enum representing the type of item
    // Common properties for all items...

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }


}